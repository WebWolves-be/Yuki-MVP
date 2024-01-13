namespace Yuki.Common.Database.Configurations;

public sealed class CompanyEntityConfiguration : BaseEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Companies");
        
        builder
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(c => c.Alias)
            .HasMaxLength(100);

        builder
            .HasMany<Invoice>(c => c.Invoices)
            .WithOne(i => i.Company)
            .HasForeignKey(i => i.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}