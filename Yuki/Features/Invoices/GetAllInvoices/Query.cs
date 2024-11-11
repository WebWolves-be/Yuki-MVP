namespace Yuki.Features.Invoices.GetAllInvoices;

public sealed record Query(bool IsLinked) : IRequest<Result<QueryResult>>;