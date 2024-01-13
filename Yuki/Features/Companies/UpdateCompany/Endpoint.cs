namespace Yuki.Features.Companies.UpdateCompany;

public static class Endpoint
{
    public static void MapUpdateCompany(this IEndpointRouteBuilder app) =>
        app.MapPut("/{companyId}", async ([FromRoute] int companyId, [FromBody] Request request, ISender mediator) =>
        {
            var result = await mediator.Send(new Command(companyId, request.Alias));

            return result.IsSuccess
                ? Results.Ok()
                : Results.BadRequest(result.Errors);
        });
}