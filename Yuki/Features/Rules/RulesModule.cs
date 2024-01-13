namespace Yuki.Features.Rules;

public class RulesModule : CarterModule
{
    public RulesModule() : base("/api/rules")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapCreateRuleEndpoint();
    }
}