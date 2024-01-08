namespace Yuki.Features.Companies.GetAllCompanies;

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
            .Select(c => new CompanyModel(c.Id, c.Name))
            .ToListAsync(cancellationToken);

        return Result<QueryResult>.Success(new QueryResult(companies));
    }
}