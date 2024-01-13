namespace Yuki.Common.Helpers;

public class Result<T> where T : class
{
    private Result(bool isSuccess, T? value, IEnumerable<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
        Value = value;
    }

    public T? Value { get; }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public IEnumerable<Error> Errors { get; }

    public static Result<T> Success(T value) => new(true, value, Enumerable.Empty<Error>());

    public static Result<T> Failure(params Error[] errors) => new(false, null, errors);

    public static Result<T> Failure(ValidationResult validationResult) => new(false, null,
        validationResult
            .Errors
            .Select(vr => new Error(vr.ErrorCode))
            .ToArray());
}