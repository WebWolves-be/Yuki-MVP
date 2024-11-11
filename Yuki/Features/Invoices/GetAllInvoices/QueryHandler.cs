namespace Yuki.Features.Invoices.GetAllInvoices;

public sealed record QueryHandler(AppDbContext DbContext) : IRequestHandler<Query, Result<QueryResult>>
{
    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var invoices = await DbContext
            .Invoices
            .AsNoTracking()
            .Where(x => x.Match == null)
            .Select(x => new InvoiceModel(
                x.YukiKey,
                x.Company.Name,
                x.Company.Alias,
                x.Subject,
                x.TotalAmount,
                x.Date))
            .ToListAsync(cancellationToken);

        return Result<QueryResult>.Success(new QueryResult(invoices));
    }
}