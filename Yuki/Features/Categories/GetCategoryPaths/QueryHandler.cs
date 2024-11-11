using Yuki.Features.Categories.GetCategoryPaths.Model;

namespace Yuki.Features.Categories.GetCategoryPaths;

public class QueryHandler(AppDbContext dbContext) : IRequestHandler<Query, Result<QueryResult>>
{
    public async Task<Result<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
    {
        var categories = await dbContext
            .Categories
            .AsNoTracking()
            .Include(c => c.Parent)
            .Include(c => c.SubCategories)
            .ToListAsync(cancellationToken);
        
        var categoryPaths = categories
            .Where(c => c.SubCategories.Count == 0)
            .Select(c => BuildCategoryPath(c, categories))
            .OrderBy(x => x.Path)
            .ToList();
        
        return Result<QueryResult>.Success(new QueryResult(categoryPaths));
    }
    
    private static CategoryPathModel BuildCategoryPath(Category category, List<Category> allCategories)
    {
        var path = new List<string>();
        var currentCategory = category;

        while (currentCategory != null)
        {
            path.Insert(0, currentCategory.Name);
            currentCategory = allCategories.FirstOrDefault(c => c.Id == currentCategory.ParentId);
        }

        return new CategoryPathModel(category.Id,string.Join(" - ", path));
    }
}