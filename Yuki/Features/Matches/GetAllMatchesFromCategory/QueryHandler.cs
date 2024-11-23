namespace Yuki.Features.Matches.GetAllMatchesFromCategory;

public sealed class QueryHandler(AppDbContext dbContext) : IRequestHandler<Query, Result<QueryResult>>
{
    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var matches = await dbContext
            .Matches
            .Where(x => x.CategoryId == request.CategoryId)
            .OrderBy(x => x.Invoice.Date)
            .Select(x => new MatchModel(
                x.Invoice.YukiKey,
                x.Invoice.Company.Name,
                x.Invoice.Company.Alias,
                x.Invoice.Subject,
                x.Invoice.TotalAmount,
                x.Invoice.Date,
                x.IsExceptionFromRule))
            .ToListAsync(cancellationToken);
        
        return Result<QueryResult>.Success(new QueryResult(matches));
    }
}