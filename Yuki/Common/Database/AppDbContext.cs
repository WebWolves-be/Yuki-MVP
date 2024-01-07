namespace Yuki.Common.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Category> Categories { get; set; } = null!;
    
    public DbSet<Company> Companies { get; set; } = null!;
    
    public DbSet<Invoice> Invoices { get; set; } = null!;
    
    public DbSet<Rule> Rules { get; set; } = null!;
}