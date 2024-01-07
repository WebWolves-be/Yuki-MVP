namespace Yuki.Common.Database.Configurations;

public sealed class InvoiceEntityConfiguration : BaseEntityConfiguration<Invoice>
{
    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {
        base.Configure(builder);

        builder.ToTable("Invoices");
        
        builder
            .HasOne<Company>(i => i.Company)
            .WithMany()
            .HasForeignKey(i => i.CompanyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .Property(i => i.YukiKey)
            .IsRequired();

        builder
            .HasIndex(i => i.YukiKey)
            .IsUnique();
        
        builder
            .Property(i => i.Subject)
            .HasMaxLength(500)
            .IsRequired();

        builder
            .Property(i => i.Amount)
            .HasPrecision(15, 2)
            .IsRequired();

        builder
            .Property(i => i.VatAmount)
            .HasPrecision(15, 2)
            .IsRequired();

        builder
            .Property(i => i.Type)
            .HasConversion(
                type => type.ToString(),
                type => (InvoiceType)Enum.Parse(typeof(InvoiceType), type))
            .IsRequired();

        builder
            .Property(i => i.Date)
            .IsRequired();
    }
}