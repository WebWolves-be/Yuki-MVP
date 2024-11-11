namespace Yuki.Features.Categories.DeleteCategory;

public record Command(int CategoryId) : IRequest<Result<CommandResult>>;