namespace Yuki.Features.Companies.UpdateCompany;

public class CommandHandler : IRequestHandler<Command, Result<CommandResult>>
{
    private readonly AppDbContext _dbContext;

    public CommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<CommandResult>> Handle(Command request, CancellationToken cancellationToken)
    {
        var company = await _dbContext
            .Companies
            .FindAsync(new object?[] { request.CompanyId }, cancellationToken: cancellationToken);

        if (company is null)
        {
            return Result<CommandResult>.Failure(Errors.CompanyNotFound);
        }
        
        company.Alias = request.Alias;

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Result<CommandResult>.Success(new CommandResult());
    }
}