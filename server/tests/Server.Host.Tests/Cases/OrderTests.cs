using System.Threading.Tasks;
using FluentAssertions;
using Server.Host.Tests.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Server.Host.Tests.Cases;

public class OrderTests : TestBase
{
    public OrderTests(ITestOutputHelper outputHelper)
        : base(outputHelper) { }

    [Fact]
    public async Task CreateOrder()
    {
        var app = await Connect();

        var orderId = await app.Order.Create().EnsureSuccess();
        orderId.Should().NotBeEmpty();
    }
}
