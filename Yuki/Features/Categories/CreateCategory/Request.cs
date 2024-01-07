namespace Yuki.Features.Categories.CreateCategory;

public record Request(string Name, int? ParentId = null);