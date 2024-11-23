namespace Yuki.Features.Invoices.GetAllInvoicesWithoutMatch.Model;

public record InvoiceWithoutMatchModel(
    int Id,
    Guid YukiKey,
    string CompanyName,
    string? CompanyAlias,
    string Subject,
    decimal Amount,
    DateOnly Date);