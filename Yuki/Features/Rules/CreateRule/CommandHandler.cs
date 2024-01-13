namespace Yuki.Features.Rules.CreateRule;

public record CommandHandler : IRequestHandler<Command, Result<CommandResult>>
{
    private readonly AppDbContext _dbContext;
    private readonly IMediator _mediator;

    public CommandHandler(AppDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }
    
    public async Task<Result<CommandResult>> Handle(Command request, CancellationToken cancellationToken)
    {
        if (await _dbContext.Rules.AnyAsync(r => r.CompanyId == request.CompanyId, cancellationToken: cancellationToken))
        {
            return Result<CommandResult>.Failure(Errors.CompanyAlreadyHasRule);
        }
        
        _dbContext.Rules.Add(new Rule
        {
            CompanyId = request.CompanyId,
            CategoryId = request.CategoryId
        });

        await _dbContext.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new CreateMatchesNotification(request.CompanyId, request.CategoryId), cancellationToken);

        return Result<CommandResult>.Success(new CommandResult());
    }
}