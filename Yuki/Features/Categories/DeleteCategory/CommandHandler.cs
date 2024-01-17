namespace Yuki.Features.Categories.DeleteCategory;

public class CommandHandler : IRequestHandler<Command, Result<CommandResult>>
{
    private readonly AppDbContext _dbContext;

    public CommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<CommandResult>> Handle(Command request, CancellationToken cancellationToken)
    {
        var category = await _dbContext
            .Categories
            .FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

        if (category is null)
        {
            throw new NullReferenceException("Category is not found!");
        }

        _dbContext.Categories.Remove(category);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<CommandResult>.Success(new CommandResult());
    }
}