namespace Yuki.Features.Rules.CreateRule;

public record Command(int CompanyId, int CategoryId) : IRequest<Result<CommandResult>>;