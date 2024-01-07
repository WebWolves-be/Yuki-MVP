namespace Yuki.Common.Database.Configurations;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IBaseEntity
{
    public virtual void  Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(baseEntity => baseEntity.Id);
        
        builder
            .Property(baseEntity => baseEntity.Id)
            .UseIdentityColumn();
    }
}