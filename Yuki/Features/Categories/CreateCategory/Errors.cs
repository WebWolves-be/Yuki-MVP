namespace Yuki.Features.Categories.CreateCategory;

public static class Errors
{
    public static readonly Error NameEmpty = new("Category.NameEmpty");
    
    public static readonly Error NameLengthExceeded = new("Category.NameLengthExceeded");
    
    public static readonly Error NameAlreadyExists = new("Category.NameAlreadyExists");
}