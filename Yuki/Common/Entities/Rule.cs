namespace Yuki.Common.Entities;

public class Rule : IBaseEntity
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public DateTime? LastModified { get; set; }
}