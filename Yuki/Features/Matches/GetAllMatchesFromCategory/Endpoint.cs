namespace Yuki.Features.Matches.GetAllMatchesFromCategory;

public static class Endpoint
{
    public static void MapGetAllMatchesFromCategoryEndpoint(this IEndpointRouteBuilder app) =>
        app.MapGet("/from-category", async ([FromQuery] int categoryId, ISender mediator) =>
        {
            var result = await mediator.Send(new Query(categoryId));

            return Results.Ok(result.Value);
        });
}