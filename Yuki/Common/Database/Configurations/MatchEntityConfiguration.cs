namespace Yuki.Common.Database.Configurations;

public sealed class MatchEntityConfiguration : BaseEntityConfiguration<Match>
{
    public override void Configure(EntityTypeBuilder<Match> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Matches");

        builder
            .HasOne(m => m.Category)
            .WithMany(c => c.Matches)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder
            .HasOne(m => m.Invoice)
            .WithOne(i => i.Match)
            .HasForeignKey<Match>(m => m.InvoiceId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        builder
            .Property(m => m.IsExceptionFromRule)
            .HasDefaultValue(false)
            .IsRequired();
    }
}