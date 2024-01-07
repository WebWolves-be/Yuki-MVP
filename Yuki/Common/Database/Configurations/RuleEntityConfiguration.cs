namespace Yuki.Common.Database.Configurations;

public class RuleEntityConfiguration : BaseEntityConfiguration<Rule>
{
    public override void Configure(EntityTypeBuilder<Rule> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Rules");
        
        builder
            .HasOne(c => c.Company)
            .WithMany()
            .HasForeignKey(i => i.CompanyId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder
            .HasOne(c => c.Category)
            .WithMany()
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder
            .HasIndex(c => new { c.CompanyId, c.CategoryId })
            .IsUnique();
    }
}