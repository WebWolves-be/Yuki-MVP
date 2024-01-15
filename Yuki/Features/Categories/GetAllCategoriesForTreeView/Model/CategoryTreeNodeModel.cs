namespace Yuki.Features.Categories.GetAllCategoriesForTreeView.Model;

public record CategoryTreeNodeModel(
    int Id,
    string Name,
    int? ParentId,
    string? CompanyName,
    List<CategoryTreeNodeModel> Children,
    List<MatchTreeNodeModel> Matches)
{
    public decimal TotalAmount => Matches.Sum(x => x.Amount + x.VatAmount);
    public decimal TotalAmountOfChildren => Children.Sum(x => x.TotalAmountOfChildren + x.TotalAmount);
}