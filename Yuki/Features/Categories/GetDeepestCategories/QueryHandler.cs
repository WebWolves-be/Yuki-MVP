namespace Yuki.Features.Categories.GetDeepestCategories;

public class QueryHandler : IRequestHandler<Query, Result<QueryResult>>
{
    private readonly AppDbContext _dbContext;

    public QueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var categories = await _dbContext
            .Categories
            .AsNoTracking()
            .Include(c => c.SubCategories)
            .Where(c => c.SubCategories.Count == 0)
            .Select(c => new CategoryModel(c.Id, c.Name))
            .ToListAsync(cancellationToken);
        
        return Result<QueryResult>.Success(new QueryResult(categories));
    }
}