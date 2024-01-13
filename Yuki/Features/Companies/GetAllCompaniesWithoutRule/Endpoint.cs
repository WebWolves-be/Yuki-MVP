namespace Yuki.Features.Companies.GetAllCompaniesWithoutRule;

public static class Endpoint
{
    public static void MapGetAllCompaniesWithoutRule(this IEndpointRouteBuilder app) =>
        app.MapGet("/without-rule", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query());

            return Results.Ok(result.Value);
        });
}