namespace Yuki.Features.Matches.CreateMatch;

public static class Endpoint
{
    public static void MapCreateMatchEndpoint(this IEndpointRouteBuilder app) =>
        app.MapPost("/", async ([FromBody] Request request, ISender mediator) =>
        {
            var result = await mediator.Send(new Command(request.InvoiceId, request.CategoryId));

            return result.IsSuccess
                ? Results.Ok()
                : Results.BadRequest(result.Errors);
        });
}