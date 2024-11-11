namespace Yuki.Features.Matches;

public class MatchesModule : CarterModule
{
    public MatchesModule() : base("/api/matches")
    {
        WithTags("Matches");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapCreateMatchEndpoint();
    }
}