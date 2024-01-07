namespace Yuki.Common;

public static class DependencyInjection
{
    public static void AddEfCore(this IServiceCollection services)
    {
        services.AddSingleton<UpdateLastModifiedInterceptor>();
        
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("YukiDb");

            options.UseSqlServer(connectionString);
            options.AddInterceptors(serviceProvider.GetRequiredService<UpdateLastModifiedInterceptor>());
        });
    }

    public static void AddQuartz(this IServiceCollection services)
    {
        services.AddQuartz(_ => {});

        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });
    }
}