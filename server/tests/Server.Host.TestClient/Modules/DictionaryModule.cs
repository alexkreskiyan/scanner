using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pathoschild.Http.Client;
using Server.Views;

namespace Server.Host.TestClient.Modules;

public class DictionaryModule
{
    private readonly IClient _http;
    private readonly ILogger<DictionaryModule> _logger;

    public DictionaryModule(IClient http, ILogger<DictionaryModule> logger)
    {
        _http = http;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<string>> GetDocumentTypes()
    {
        _logger.LogTrace("start");

        var result = await _http.GetAsync("api/1.0/dictionary/document-types").AsArray<string>();

        _logger.LogTrace("done");

        return result;
    }

    public async Task<
        IReadOnlyDictionary<string, DocumentFieldConfigurationResponse>
    > GetDocumentFields()
    {
        _logger.LogTrace("start");

        var result = await _http
            .GetAsync("api/1.0/dictionary/document-fields")
            .As<Dictionary<string, DocumentFieldConfigurationResponse>>();

        _logger.LogTrace("done");

        return result;
    }

    public async Task<IReadOnlyCollection<string>> GetDocumentPages()
    {
        _logger.LogTrace("start");

        var result = await _http.GetAsync("api/1.0/dictionary/document-pages").AsArray<string>();

        _logger.LogTrace("done");

        return result;
    }
}
