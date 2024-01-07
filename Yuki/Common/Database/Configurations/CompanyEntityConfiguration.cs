namespace Yuki.Common.Database.Configurations;

public class CompanyEntityConfiguration : BaseEntityConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Companies");
        
        builder
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}