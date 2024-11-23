namespace Yuki.Features.Matches.GetAllMatchesFromCategory;

public sealed record QueryResult(IEnumerable<MatchModel> Matches);