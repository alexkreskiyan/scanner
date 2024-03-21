using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Server.Host.TestClient.Modules;

public class AppModule : IAsyncDisposable
{
    public DictionaryModule Dictionary { get; }
    public OrderModule Order { get; }
    private AsyncServiceScope? _scope;
    private readonly ILogger<AppModule> _logger;

    public AppModule(DictionaryModule dictionary, OrderModule order, ILogger<AppModule> logger)
    {
        Dictionary = dictionary;
        Order = order;
        _logger = logger;
    }

    public void InitScope(AsyncServiceScope scope)
    {
        _logger.LogTrace("start");

        if (_scope is not null)
            throw new InvalidOperationException("App scope is already set");

        _scope = scope;

        _logger.LogTrace("done");
    }

    public async ValueTask DisposeAsync()
    {
        _logger.LogTrace("start");

        if (_scope.HasValue)
            await _scope.Value.DisposeAsync();
        else
            throw new InvalidOperationException("App scope was not set");

        _logger.LogTrace("done");
    }
}
