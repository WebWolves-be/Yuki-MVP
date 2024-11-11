using Yuki.Features.Invoices.Yuki;

namespace Yuki.Features.Invoices;

public static class DependencyInjection
{
    public static void AddInvoicesFeature(this IServiceCollection services)
    {
        services.ConfigureOptions<YukiBackgroundJobSetup>();
    }
}