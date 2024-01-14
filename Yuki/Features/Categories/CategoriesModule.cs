namespace Yuki.Features.Categories;

public class CategoriesModule : CarterModule
{
    public CategoriesModule() : base("/api/categories")
    {
        WithTags("Categories");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGetAllCategoriesForTreeViewEndpoint();
        app.MapGetDeepestCategoriesEndpoint();
        app.MapCreateCategoryEndpoint();
    }
}