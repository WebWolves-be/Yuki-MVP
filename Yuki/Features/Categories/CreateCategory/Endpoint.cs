namespace Yuki.Features.Categories.CreateCategory;

public static class Endpoint
{
    public static void MapCreateCategoryEndpoint(this IEndpointRouteBuilder app) =>
        app.MapPost("/", async ([FromBody] Request request, ISender mediator) =>
        {
            var result = await mediator.Send(new Command(request.Name, request.ParentId));

            return result.IsSuccess 
                ? Results.Ok(new Response(result.Value!.Id)) 
                : Results.BadRequest(result.Errors);
        });
}