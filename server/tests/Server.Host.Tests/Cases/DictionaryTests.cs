using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace Server.Host.Tests.Cases;

public class DictionaryTests : TestBase
{
    public DictionaryTests(ITestOutputHelper outputHelper)
        : base(outputHelper) { }

    [Fact]
    public async Task DocumentTypes_Available()
    {
        Logger.LogInformation("Settings: {Settings}", TestSettings.Current);
        await Task.CompletedTask;
    }
}
