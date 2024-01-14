namespace Yuki.Features.Categories.GetAllCategoriesForTreeView;

public record QueryResult(IEnumerable<CategoryTreeNodeModel> Categories);