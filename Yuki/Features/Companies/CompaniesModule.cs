
namespace Yuki.Features.Companies;

public class CompaniesModule : CarterModule
{
    public CompaniesModule() : base("/api/companies")
    {
        WithTags("Companies");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGetAllCompanies();
        app.MapGetAllCompaniesWithoutRule();
        app.MapUpdateCompany();
    }
}