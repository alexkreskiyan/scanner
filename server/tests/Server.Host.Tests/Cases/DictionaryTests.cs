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
    public async Task Documents_Available()
    {
        var app = await Connect();

        var documents = await app.Dictionary.GetDocuments();

        documents.Should().NotBeEmpty();
        documents
            .Should()
            .AllSatisfy(doc =>
            {
                doc.Key.Should().NotBeEmpty();
                doc.Value.Should().NotBeNull();
                doc.Value.Fields.Should()
                    .AllSatisfy(field =>
                    {
                        field.Key.Should().NotBeEmpty();
                        field.Value.Should().NotBeNull();
                        field.Value.Label.Should().NotBeEmpty();
                        field.Value.DataType.Should().NotBeEmpty();
                    });
                doc.Value.Pages.Should().AllSatisfy(page => page.Should().NotBeEmpty());
            });
    }
}
