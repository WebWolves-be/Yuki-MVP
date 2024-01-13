namespace Yuki.Features.Rules.CreateRule;

public static class Endpoint
{
    public static void MapCreateRuleEndpoint(this IEndpointRouteBuilder app) =>
        app.MapPost("/", async ([FromBody] Request request, ISender mediator) =>
        {
            var result = await mediator.Send(new Command(request.CompanyId, request.CategoryId));

            return result.IsSuccess
                ? Results.Ok()
                : Results.BadRequest(result.Errors);
        });
}