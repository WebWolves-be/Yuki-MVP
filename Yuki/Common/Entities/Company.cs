namespace Yuki.Common.Entities;

public class Company : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Alias { get; set; }
    
    public DateTime? LastModified { get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}