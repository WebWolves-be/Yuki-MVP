namespace Yuki.Common.Database.Configurations;

public sealed class RuleEntityConfiguration : BaseEntityConfiguration<Rule>
{
    public override void Configure(EntityTypeBuilder<Rule> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Rules");
        
        builder
            .HasOne(r => r.Company)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        builder
            .HasOne(r => r.Category)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}