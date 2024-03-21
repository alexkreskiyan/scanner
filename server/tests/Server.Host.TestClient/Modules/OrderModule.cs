using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Extensions.Data;
using Microsoft.Extensions.Logging;
using Pathoschild.Http.Client;
using Server.Views;

namespace Server.Host.TestClient.Modules;

public class OrderModule
{
    private readonly IClient _http;
    private readonly ILogger<OrderModule> _logger;

    public OrderModule(IClient http, ILogger<OrderModule> logger)
    {
        _http = http;
        _logger = logger;
    }

    public async Task<Result<Guid>> Create()
    {
        _logger.LogTrace("start");

        var result = await _http
            .PostAsync("api/1.0/order")
            .WithBody(new OrderRequest { DocumentTypes = new List<string> { "passport" } })
            .As<Result<Guid>>();

        _logger.LogTrace("done");

        return result;
    }
}
