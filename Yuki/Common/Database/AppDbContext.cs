namespace Yuki.Common.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Category> Categories => Set<Category>();
    
    public DbSet<Company> Companies => Set<Company>();
    
    public DbSet<Invoice> Invoices => Set<Invoice>();
    
    public DbSet<Match> Matches => Set<Match>();
    
    public DbSet<Rule> Rules => Set<Rule>();
}