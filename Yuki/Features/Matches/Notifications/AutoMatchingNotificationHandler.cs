namespace Yuki.Features.Matches.Notifications;

public class AutoMatchingNotificationHandler(AppDbContext dbContext) : INotificationHandler<AutoMatchingNotification>
{
    public async Task Handle(AutoMatchingNotification notification, CancellationToken cancellationToken)
    {
        var invoicesToMatch = await dbContext
            .Invoices
            .Where(i => i.Match == null)
            .ToListAsync(cancellationToken);

        var companyIds = invoicesToMatch
            .Select(x => x.CompanyId)
            .Distinct()
            .ToList();

        var rules = await dbContext
            .Rules
            .Where(r => companyIds.Contains(r.CompanyId))
            .ToListAsync(cancellationToken);

        foreach (var rule in rules)
        {
            dbContext.Matches.AddRange(
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

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}