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

    public async Task<IReadOnlyDictionary<string, DocumentConfigurationResponse>> GetDocuments()
    {
        _logger.LogTrace("start");

        var result = await _http
            .GetAsync("api/1.0/dictionary/documents")
            .As<Dictionary<string, DocumentConfigurationResponse>>();

        _logger.LogTrace("done");

        return result;
    }
}
