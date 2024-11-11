namespace Yuki.Features.Invoices.GetAllInvoices.Model;

public record InvoiceModel(
    Guid YukiKey,
    string CompanyName,
    string? CompanyAlias,
    string Subject,
    decimal Amount,
    DateOnly Date);