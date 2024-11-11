namespace Yuki.Features.Categories.DeleteCategory;

public static class Endpoint
{
    public static void MapDeleteCategoryEndpoint(this IEndpointRouteBuilder app) =>
        app.MapDelete("/{categoryId}", async ([FromRoute] int categoryId, ISender mediator) =>
        {
            await mediator.Send(new Command(categoryId));

            return Results.Ok();
        });
}