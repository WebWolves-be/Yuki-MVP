namespace Yuki.Common.Entities;

public class Rule : IBaseEntity
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public DateTime? LastModified { get; set; }
}