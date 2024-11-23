namespace Yuki.Features.Matches.GetAllMatchesFromCategory;

public sealed record Query(int CategoryId) : IRequest<Result<QueryResult>>;