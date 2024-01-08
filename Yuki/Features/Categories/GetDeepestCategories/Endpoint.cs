namespace Yuki.Features.Categories.GetDeepestCategories;

public static class Endpoint
{
    public static void MapGetDeepestCategoriesEndpoint(this IEndpointRouteBuilder app) =>
        app.MapGet("/deepest", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query());

            return Results.Ok(result.Value);
        });
}