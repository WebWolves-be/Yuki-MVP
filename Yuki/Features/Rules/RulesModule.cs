namespace Yuki.Features.Rules;

public class RulesModule : CarterModule
{
    public RulesModule() : base("/api/rules")
    {
        WithTags("Rules");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapCreateRuleEndpoint();
    }
}