namespace Yuki.Features.Categories.GetAllCategoriesForTreeView;

public static class Endpoint
{
    public static void MapGetAllCategoriesForTreeViewEndpoint(this IEndpointRouteBuilder app) =>
        app.MapGet("/tree-view", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query());

            return Results.Ok(result.Value?.Categories);
        });
}