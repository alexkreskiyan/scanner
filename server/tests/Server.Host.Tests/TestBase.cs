using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Server.Host.TestClient;
using Server.Host.TestClient.Modules;
using Xunit.Abstractions;

namespace Server.Host.Tests;

public class TestBase : Lib.TestBase
{
    protected TestBase(ITestOutputHelper outputHelper)
        : base(outputHelper)
    {
        Register(services => services.AddTestClient());
    }

    protected Task<AppModule> Connect()
    {
        Logger.LogTrace("start");

        Logger.LogTrace("create scope");
        var scope = Get<IServiceProvider>().CreateAsyncScope();
        var sp = scope.ServiceProvider;

        Logger.LogTrace("create app module");
        var app = sp.GetRequiredService<AppModule>();

        Logger.LogTrace("init app with scope");
        app.InitScope(scope);

        Logger.LogTrace("done");

        return Task.FromResult(app);
    }
}
