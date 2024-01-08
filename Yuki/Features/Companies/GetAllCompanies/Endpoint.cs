namespace Yuki.Features.Companies.GetAllCompanies;

public static class Endpoint
{
    public static void MapGetAllCompanies(this IEndpointRouteBuilder app) =>
        app.MapGet("/", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query());

            return Results.Ok(result.Value);
        });
}