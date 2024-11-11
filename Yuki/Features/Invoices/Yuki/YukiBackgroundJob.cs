using Yuki.Features.Invoices.Yuki.Xml;
using XmlDocument = Yuki.Features.Invoices.Yuki.Xml.XmlDocument;

namespace Yuki.Features.Invoices.Yuki;

[DisallowConcurrentExecution]
public class YukiBackgroundJob : IJob
{
    private readonly ILogger<YukiBackgroundJob> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IMediator _mediator;

    public YukiBackgroundJob(ILogger<YukiBackgroundJob> logger, AppDbContext dbContext, IMediator mediator)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("YukiBackgroundJob Executed on {UtcNow}!", DateTime.UtcNow);

        var xmlDocument = await GetDocumentsFromYukiSoapClient();

        if (xmlDocument is null)
        {
            _logger.LogError("No documents could be fetched from Yuki SOAP service!");
            return;
        }

        await ProcessInvoices(xmlDocument);

        await CleanUp(xmlDocument);

        await _mediator.Publish(new AutoMatchingNotification());

        _logger.LogInformation("YukiBackgroundJob Finished on {UtcNow}!", DateTime.UtcNow);
    }

    private async Task<XmlDocuments?> GetDocumentsFromYukiSoapClient()
    {
        var client = new ArchiveSoapClient(ArchiveSoapClient.EndpointConfiguration.ArchiveSoap);
        var sessionId = await client.AuthenticateAsync("cb4389d0-95e7-4866-b213-03d5b2ec280b");

        //var year = DateTime.Today.Year - 1;

        var documents = await client.DocumentsInFolderAsync(
            sessionId,
            1,
            DocumentSortOrder.CreatedAsc,
            new DateTime(DateTime.Today.Year, 1, 1),
            new DateTime(DateTime.Today.Year, 12, 31),
            100000,
            0);

        var serializer = new XmlSerializer(typeof(XmlDocuments));

        using var reader = new XmlNodeReader(documents);
        var result = (XmlDocuments?)serializer.Deserialize(reader);

        _logger.LogInformation("{Total} Total Documents", result?.Document.Count);

        return result;
    }

    private async Task ProcessInvoices(XmlDocuments xmlDocument)
    {
        //todo: parse double to decimal and keep precision

        var createdCounter = 0;
        var updatedCounter = 0;

        foreach (var document in xmlDocument.Document)
        {
            if (string.IsNullOrEmpty(document.ContactName))
            {
                _logger.LogInformation("Document with ID {DocumentId} has empty contact name", document.ID);
                continue;
            }

            if (string.IsNullOrEmpty(document.Subject))
            {
                _logger.LogInformation("Document with ID {DocumentId} has empty subject", document.ID);
                continue;
            }

            var existingInvoice = await _dbContext
                .Invoices
                .Where(x => x.YukiKey == Guid.Parse(document.ID))
                .SingleOrDefaultAsync();

            if (existingInvoice is null)
            {
                _dbContext
                    .Invoices
                    .Add(new Invoice
                    {
                        Company = await GetCompany(document),
                        YukiKey = Guid.Parse(document.ID),
                        Subject = document.Subject,
                        Amount = Convert.ToDecimal(document.Amount),
                        VatAmount = Convert.ToDecimal(document.VatAmount),
                        Type = InvoiceType.Purchase,
                        Date = DateOnly.FromDateTime(document.DocumentDate),
                    });

                createdCounter++;
            }
            else
            {
                existingInvoice.Subject = document.Subject;
                existingInvoice.Amount = Convert.ToDecimal(document.Amount);
                existingInvoice.VatAmount = Convert.ToDecimal(document.VatAmount);
                existingInvoice.Date = DateOnly.FromDateTime(document.DocumentDate);

                updatedCounter++;
            }
            
            await _dbContext.SaveChangesAsync();
        }

        _logger.LogInformation("{Created} Created Invoices", createdCounter);
        _logger.LogInformation("{Updated} Updated Invoices", updatedCounter);
    }

    private async Task<Company> GetCompany(XmlDocument document)
    {
        var contactName = document.ContactName.Trim();

        var existingCompany = await _dbContext
            .Companies
            .Where(x => x.Name == contactName)
            .SingleOrDefaultAsync();

        Company? company;

        if (existingCompany is null)
        {
            company = new Company
            {
                Name = contactName
            };
        }
        else
        {
            company = existingCompany;
        }

        return company;
    }

    private async Task CleanUp(XmlDocuments xmlDocument)
    {
        //todo: if company from deleted invoice has no more invoices, delete company as well
        //todo: also clean up rules if company is deleted

        var allExistingInvoices = await _dbContext
            .Invoices
            .Select(i => i.YukiKey)
            .ToListAsync();

        var allDocuments = xmlDocument.Document
            .Select(d => Guid.Parse(d.ID))
            .ToList();

        var invoicesToDelete = allExistingInvoices.Except(allDocuments);

        var deletedInvoices = await _dbContext
            .Invoices
            .Where(i => invoicesToDelete.Contains(i.YukiKey))
            .ExecuteDeleteAsync();

        _logger.LogInformation("{InvoicesToDelete} Invoices To Delete", invoicesToDelete.Count());
        _logger.LogInformation("{DeletedInvoices} Deleted Invoices", deletedInvoices);
    }
}