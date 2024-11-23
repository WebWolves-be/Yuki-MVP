namespace Yuki.Features.Invoices.GetAllInvoicesWithoutMatch;

public static class Endpoint
{
    public static void MapGetAllInvoicesWithoutMatch(this IEndpointRouteBuilder app) =>
        app.MapGet("/without-match", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query());

            return Results.Ok(result.Value);
        });
}