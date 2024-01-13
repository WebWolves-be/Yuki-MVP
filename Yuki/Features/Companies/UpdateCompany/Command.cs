namespace Yuki.Features.Companies.UpdateCompany;

public record Command(int CompanyId, string Alias) : IRequest<Result<CommandResult>>;