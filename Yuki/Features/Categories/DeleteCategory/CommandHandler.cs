using Ardalis.GuardClauses;

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
            .SingleOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken: cancellationToken);

        Guard.Against.Null(category, nameof(category), $"Category with id {request.CategoryId} is not found!");
        
        _dbContext.Categories.Remove(category);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<CommandResult>.Success(new CommandResult());
    }
}