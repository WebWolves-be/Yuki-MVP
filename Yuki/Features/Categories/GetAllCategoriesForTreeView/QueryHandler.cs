namespace Yuki.Features.Categories.GetAllCategoriesForTreeView;

public class QueryHandler : IRequestHandler<Query, Result<QueryResult>>
{
    private readonly AppDbContext _dbContext;

    public QueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories
            .Include(c => c.Parent)
            .Include(c => c.Matches)
            .ThenInclude(m => m.Invoice)
            .ThenInclude(i => i.Company)
            .ToListAsync(cancellationToken);

        FilterOutDuplicates(categories);
        
        var categoryTreeModels = categories
            .Select(category => new CategoryTreeNodeModel(
                category.Id,
                category.Name,
                category.ParentId,
                MapCompanyName(category),
                MapSubCategories(category),
                MapMatches(category))
            )
            .ToList();

        return Result<QueryResult>.Success(new QueryResult(categoryTreeModels));
    }

    private static void FilterOutDuplicates(List<Category> categories)
    {
        for (var index = 0; index < categories.Count; index++)
        {
            var category = categories[index];
            
            if (category.ParentId is not null)
            {
                categories.RemoveAt(index);
                index--;
            }
        }
    }

    private static string? MapCompanyName(Category category)
    {
        if (category.Matches.Count == 0)
        {
            return string.Empty;
        }

        return category
            .Matches
            .Select(m => m.Invoice.Company.Name)
            .FirstOrDefault();
    }

    private static List<CategoryTreeNodeModel> MapSubCategories(Category category)
    {
        return category
            .SubCategories
            .Select(c => new CategoryTreeNodeModel(
                c.Id,
                c.Name,
                c.ParentId,
                MapCompanyName(c),
                MapSubCategories(c),
                MapMatches(c))
            ).ToList();
    }

    private static List<MatchTreeNodeModel> MapMatches(Category category)
    {
        return category
            .Matches
            .Select(m => new MatchTreeNodeModel(
                m.Invoice.Amount,
                m.Invoice.VatAmount
            ))
            .ToList();
    }
}