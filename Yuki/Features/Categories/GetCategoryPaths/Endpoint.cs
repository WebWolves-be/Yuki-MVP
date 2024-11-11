namespace Yuki.Features.Categories.GetCategoryPaths;

public static class Endpoint
{
    public static void MapGetCategoryPathsEndpoint(this IEndpointRouteBuilder app) =>
        app.MapGet("/paths", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query());

            return Results.Ok(result.Value);
        });
}