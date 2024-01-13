namespace Yuki.Common.Database.Configurations;

public sealed class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("Categories");
        
        builder
            .Property(c => c.Year)
            .IsRequired();
        
        builder
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .HasOne<Category>(c => c.Parent)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasMany<Match>(c => c.Matches)
            .WithOne(m => m.Category)
            .HasForeignKey(m => m.CategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}