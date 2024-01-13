namespace Yuki.Features.Companies.GetAllCompaniesWithoutRule;

public class QueryHandler : IRequestHandler<Query, Result<QueryResult>>
{
    private readonly AppDbContext _dbContext;

    public QueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var companies = await _dbContext
            .Companies
            .AsNoTracking()
            .Where(c => _dbContext.Rules.All(r => r.CompanyId != c.Id))
            .Select(c => new CompanyModel(c.Id, c.Name, c.Alias))
            .ToListAsync(cancellationToken);

        return Result<QueryResult>.Success(new QueryResult(companies));
    }
}