namespace Yuki.Features.Invoices;

public class InvoicesModule : CarterModule
{
    public InvoicesModule(): base("/api/invoices")
    {
        WithTags("Invoices");
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGetAllInvoicesWithoutMatch();
    }
}