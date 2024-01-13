namespace Yuki.Features.Matches.Notifications;

public class CreateMatchesNotificationHandler : INotificationHandler<CreateMatchesNotification>
{
    private readonly AppDbContext _dbContext;

    public CreateMatchesNotificationHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateMatchesNotification notification, CancellationToken cancellationToken)
    {
        var invoicesToMatch = await _dbContext
            .Invoices
            .Where(i => i.CompanyId == notification.CompanyId && i.Match == null)
            .ToListAsync(cancellationToken);

        _dbContext.Matches.AddRange(
            invoicesToMatch.Select(x => new Match
            {
                CategoryId = notification.CategoryId,
                InvoiceId = x.Id,
                IsExceptionFromRule = false
            })
        );

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}