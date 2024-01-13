namespace Yuki.Features.Matches.Notifications;

public class AutoMatchingNotificationHandler : INotificationHandler<AutoMatchingNotification>
{
    private readonly AppDbContext _dbContext;

    public AutoMatchingNotificationHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AutoMatchingNotification notification, CancellationToken cancellationToken)
    {
        var invoicesToMatch = await _dbContext
            .Invoices
            .Where(i => i.Match == null)
            .ToListAsync(cancellationToken);

        var companyIds = invoicesToMatch
            .Select(x => x.CompanyId)
            .Distinct()
            .ToList();

        var rules = await _dbContext
            .Rules
            .Where(r => companyIds.Contains(r.CompanyId))
            .ToListAsync(cancellationToken);

        foreach (var rule in rules)
        {
            _dbContext.Matches.AddRange(
                invoicesToMatch
                    .Where(x => x.CompanyId == rule.CompanyId)
                    .Select(x => new Match
                    {
                        CategoryId = rule.CategoryId,
                        InvoiceId = x.Id,
                        IsExceptionFromRule = false
                    })
            );
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}