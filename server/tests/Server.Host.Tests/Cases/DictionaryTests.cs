using System.Threading.Tasks;
using FluentAssertions;
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
        var app = await Connect();

        var documentTypes = await app.Dictionary.GetDocumentTypes();

        documentTypes.Should().NotBeEmpty();
    }

    [Fact]
    public async Task DocumentFields_Available()
    {
        var app = await Connect();

        var documentTypes = await app.Dictionary.GetDocumentFields();

        documentTypes.Should().NotBeEmpty();
    }

    [Fact]
    public async Task DocumentPages_Available()
    {
        var app = await Connect();

        var documentTypes = await app.Dictionary.GetDocumentPages();

        documentTypes.Should().NotBeEmpty();
    }
}
