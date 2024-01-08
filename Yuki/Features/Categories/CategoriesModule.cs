namespace Yuki.Features.Categories;

public class CategoriesModule : CarterModule
{
    public CategoriesModule() : base("/api/categories")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapCreateCategoryEndpoint();
        app.MapGetDeepestCategoriesEndpoint();
    }
}