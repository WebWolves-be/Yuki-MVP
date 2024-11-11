namespace Yuki.Features.Matches.Notifications;

public class CreateMatchesNotificationHandler(AppDbContext dbContext) : INotificationHandler<CreateMatchesNotification>
{
    public async Task Handle(CreateMatchesNotification notification, CancellationToken cancellationToken)
    {
        var invoicesToMatch = await dbContext
            .Invoices
            .Where(i => i.CompanyId == notification.CompanyId && i.Match == null)
            .ToListAsync(cancellationToken);

        dbContext.Matches.AddRange(
            invoicesToMatch.Select(x => new Match
            {
                CategoryId = notification.CategoryId,
                InvoiceId = x.Id,
                IsExceptionFromRule = false
            })
        );

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}