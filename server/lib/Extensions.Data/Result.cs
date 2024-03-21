using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Extensions.Data;

public sealed record Result
{
    public static Result Ok() => new(string.Empty);

    public static Result Fail(string error) => new(error);

    public static Result<T> Ok<T>(T data)
        where T : notnull => new(data, string.Empty);

    public static Result<T> Fail<T>(T data, string error)
        where T : notnull => new(data, error);

    public static Result From<T>(Result<T> result)
        where T : notnull => new(result.Error);

    public static Result<T> From<T>(Result result, T value)
        where T : notnull => new(value, result.Error);

    public static Result<T> From<TOther, T>(Result<TOther> result, T value)
        where TOther : notnull
        where T : notnull => new(value, result.Error);

    [JsonIgnore]
    public bool IsSuccess => string.IsNullOrWhiteSpace(Error);

    [JsonIgnore]
    public bool IsFailure => !string.IsNullOrWhiteSpace(Error);

    public string Error { get; }

    [JsonConstructor]
    public Result(string error)
    {
        Error = error;
    }

    public override string ToString() => IsSuccess ? "OK" : Error;
}

public class Result<T>
    where T : notnull
{
    [MemberNotNullWhen(true, nameof(Data))]
    [JsonIgnore]
    public bool IsSuccess => string.IsNullOrWhiteSpace(Error);

    [MemberNotNullWhen(false, nameof(Data))]
    [JsonIgnore]
    public bool IsFailure => !string.IsNullOrWhiteSpace(Error);

    public T? Data { get; }

    public string Error { get; }

    [JsonConstructor]
    public Result(T data, string error)
    {
        Data = data;
        Error = error;
    }

    public override string ToString() => $"({Error}): {Data}";
}
