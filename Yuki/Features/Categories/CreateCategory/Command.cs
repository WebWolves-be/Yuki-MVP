namespace Yuki.Features.Categories.CreateCategory;

public record Command(string Name, int? ParentId = null) : IRequest<Result<CommandResult>>;