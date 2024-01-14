namespace Yuki.Common.Entities;

public class Invoice : IBaseEntity
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    
    public Match? Match { get; set; }

    public Guid YukiKey { get; set; }

    public string Subject { get; set; } = null!;

    public decimal Amount { get; set; }

    public decimal VatAmount { get; set; }
    
    public InvoiceType Type { get; set; }
    
    public DateOnly Date { get; set; }
    
    public DateTime? LastModified { get; set; }
}