namespace Yuki.Features.Invoices.GetAllInvoicesWithoutMatch;

public sealed record QueryHandler(AppDbContext DbContext) : IRequestHandler<Query, Result<QueryResult>>
{
    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var invoices = await DbContext
            .Invoices
            .AsNoTracking()
            .Where(x => x.Match == null)
            .Select(x => new InvoiceWithoutMatchModel(
                x.Id,
                x.YukiKey,
                x.Company.Name,
                x.Company.Alias,
                x.Subject,
                x.Amount,
                x.Date))
            .ToListAsync(cancellationToken);

        return Result<QueryResult>.Success(new QueryResult(invoices));
    }
}