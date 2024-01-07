namespace Yuki.Features.Categories.CreateCategory;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithErrorCode(Errors.NameEmpty.Code);

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithErrorCode(Errors.NameLengthExceeded.Code);
    }   
}