namespace Yuki.Common.Database.Configurations;

public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("Categories");
        
        builder
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .HasOne<Category>(c => c.Parent)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}