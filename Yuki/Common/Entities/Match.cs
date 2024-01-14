namespace Yuki.Common.Entities;

public class Match : IBaseEntity
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;

    public bool IsExceptionFromRule { get; set; }
    
    public DateTime? LastModified { get; set; }
}