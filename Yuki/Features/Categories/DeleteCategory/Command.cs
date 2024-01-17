namespace Yuki.Features.Categories.DeleteCategory;

public record Command(int Id) : IRequest<Result<CommandResult>>;