namespace Yuki.Features.Invoices.GetAllInvoicesWithoutMatch;

public sealed record QueryResult(IEnumerable<InvoiceWithoutMatchModel> Invoices);