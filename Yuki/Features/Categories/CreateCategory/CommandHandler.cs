namespace Yuki.Features.Categories.CreateCategory;

public class CommandHandler : IRequestHandler<Command, Result<CommandResult>>
{
    private readonly AppDbContext _dbContext;
    private readonly IValidator<Command> _validator;

    public CommandHandler(AppDbContext dbContext, IValidator<Command> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    public async Task<Result<CommandResult>> Handle(Command request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result<CommandResult>.Failure(validationResult);
        }

        if (await _dbContext.Categories.AnyAsync(c => c.Name == request.Name, cancellationToken: cancellationToken))
        {
            return Result<CommandResult>.Failure(Errors.NameAlreadyExists);
        }

        var category = new Category
        {
            Name = request.Name,
            ParentId = request.ParentId
        };

        _dbContext.Categories.Add(category);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<CommandResult>.Success(new CommandResult(category.Id));
    }
}