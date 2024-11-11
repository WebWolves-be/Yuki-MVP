namespace Yuki.Features.Invoices.GetAllInvoices;

public static class Endpoint
{
    public static void MapGetAllInvoices(this IEndpointRouteBuilder app) =>
        app.MapGet("/", async (ISender mediator) =>
        {
            var result = await mediator.Send(new Query(false));

            return Results.Ok(result.Value);
        });
}