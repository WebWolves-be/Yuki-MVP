namespace Yuki.Features.Matches.GetAllMatchesFromCategory.Model;

public record MatchModel(
    Guid InvoiceYukiKey,
    string InvoiceCompanyName,
    string? InvoiceCompanyAlias,
    string InvoiceSubject,
    decimal InvoiceAmount,
    DateOnly InvoiceDate,
    bool IsExceptionFromRule
);