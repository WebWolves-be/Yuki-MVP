namespace Yuki.Features.Invoices.GetInvoicesFromYuki;

public class YukiBackgroundJobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        //todo: set correct daily time interval schedule
        
        var jobKey = JobKey.Create(nameof(YukiBackgroundJob));
        
        options
            .AddJob<YukiBackgroundJob>(jobBuilder =>
            {
                jobBuilder.WithIdentity(jobKey);
            })
            .AddTrigger(trigger => trigger
                .ForJob(jobKey)
                .WithDailyTimeIntervalSchedule(triggerBuilder =>
                {
                    //triggerBuilder.OnEveryDay();
                    
                    triggerBuilder.WithIntervalInHours(24)
                        .OnEveryDay()
                        .StartingDailyAt(new TimeOfDay(5, 0, 0));
                })
            );
    }
}