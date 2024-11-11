using Yuki.Features.Categories.GetCategoryPaths.Model;

namespace Yuki.Features.Categories.GetCategoryPaths;

public record QueryResult(IEnumerable<CategoryPathModel> CategoryPaths);