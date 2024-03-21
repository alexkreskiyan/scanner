using Xunit.Abstractions;

namespace Server.Host.Tests;

public class TestBase : Lib.TestBase
{
    protected TestBase(ITestOutputHelper outputHelper)
        : base(outputHelper)
    {
        // Register(services => services.AddTestClient());
    }
    //
    // protected Task<AppModule> Connect()
    // {
    //     this.Trace("start");
    //
    //     this.Trace("create scope");
    //     var scope = Get<IServiceProvider>().CreateAsyncScope();
    //     var sp = scope.ServiceProvider;
    //
    //     this.Trace("create app module");
    //     var app = sp.GetRequiredService<AppModule>();
    //
    //     this.Trace("init app with scope");
    //     app.InitScope(scope);
    //
    //     this.Trace("done");
    //
    //     return Task.FromResult(app);
    // }
}
