
namespace Yuki.Features.Invoices.GetAllInvoices;

public sealed record QueryResult(IEnumerable<InvoiceModel> Invoices);