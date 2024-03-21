using System.Threading.Tasks;
using Extensions.Data;
using FluentAssertions;

namespace Server.Host.Tests.Extensions;

public static class ResultExtensions
{
    public static async Task EnsureSuccess(this Task<Result> resultTask)
    {
        var result = await resultTask;

        result.Error.Should().BeNullOrWhiteSpace();
        result.IsSuccess.Should().BeTrue();
    }

    public static async Task<T> EnsureSuccess<T>(this Task<Result<T>> resultTask)
        where T : notnull
    {
        var result = await resultTask;

        result.Error.Should().BeNullOrWhiteSpace();
        result.IsSuccess.Should().BeTrue();

        return result.Data!;
    }

    public static async Task EnsureFailure(this Task<Result> resultTask)
    {
        var result = await resultTask;

        result.Error.Should().NotBeNullOrWhiteSpace();
        result.IsSuccess.Should().BeFalse();
    }

    public static async Task EnsureFailure<T>(this Task<Result<T>> resultTask)
        where T : notnull
    {
        var result = await resultTask;

        result.Error.Should().NotBeNullOrWhiteSpace();
        result.IsSuccess.Should().BeFalse();
    }
}
