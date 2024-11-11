namespace Yuki.Features.Matches.CreateMatch;

public sealed class CommandHandler(AppDbContext dbContext) : IRequestHandler<Command, Result<CommandResult>>
{
    public async Task<Result<CommandResult>> Handle(Command request, CancellationToken cancellationToken)
    {
        dbContext.Matches.Add(
            new Match
            {
                CategoryId = request.CategoryId,
                InvoiceId = request.InvoiceId,
                IsExceptionFromRule = true
            });

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result<CommandResult>.Success(new CommandResult());
    }
}