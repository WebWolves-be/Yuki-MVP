namespace Yuki.Common.Entities;

public class Category : IBaseEntity
{
    public int Id { get; set; }

    public int Year { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }
    public Category? Parent { get; set; }
    
    public DateTime? LastModified { get; set; }

    public ICollection<Category> SubCategories { get; set; } = new List<Category>();

    public ICollection<Match> Matches { get; set; } = new List<Match>();
}