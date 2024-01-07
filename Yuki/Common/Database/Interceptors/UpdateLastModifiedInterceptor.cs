namespace Yuki.Common.Database.Interceptors;

internal sealed class UpdateLastModifiedInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            var entities = eventData
                .Context
                .ChangeTracker
                .Entries<IBaseEntity>()
                .ToList();

            foreach (var entry in entities)
            {
                if (entry.State is EntityState.Added or EntityState.Modified)
                {
                    entry.Property(nameof(IBaseEntity.LastModified)).CurrentValue = DateTime.Now.ToLocalTime();
                }
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}