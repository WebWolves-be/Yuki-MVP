namespace Yuki.Features.Matches.CreateMatch;

public sealed record Command(int InvoiceId, int CategoryId) : IRequest<Result<CommandResult>>;