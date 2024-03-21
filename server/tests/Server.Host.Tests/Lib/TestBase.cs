using System;
using Xunit.Abstractions;

namespace Server.Host.Tests;

public abstract class TestBase
{
    public ILogger Logger => _logger.Value;
    private bool _isBuilt;
    private readonly IServiceCollection _services;
    private readonly Lazy<IServiceProvider> _sp;
    private readonly Lazy<ILogger> _logger;

    protected TestBase(ITestOutputHelper outputHelper)
    {
        _services = new ServiceCollection();

        _services.AddSingleton(outputHelper);
        Register(SharedRegister(outputHelper));

        _sp = new Lazy<IServiceProvider>(BuildServiceProvider, true);
        _logger = new Lazy<ILogger>(() => Get<ILoggerFactory>().CreateLogger(GetType()), true);
    }

    protected void Register(Action<IServiceCollection> register)
    {
        EnsureNotBuilt();
        register(_services);
    }

    protected void Setup(Action<IServiceProvider> setup)
    {
        setup(_sp.Value);
    }

    protected T Get<T>()
        where T : notnull
    {
        return _sp.Value.GetRequiredService<T>();
    }

    private Action<IServiceCollection> SharedRegister(ITestOutputHelper outputHelper) =>
        services =>
        {
            LogBuilder
                .DefaultConfiguration()
                .WriteTo.TestOutput(outputHelper, LogEventLevel.Verbose, LogBuilder.OutputTemplate)
                .CreateLogger()
                .ForContext(GetType())
                .RegisterTo(services);
        };

    private IServiceProvider BuildServiceProvider()
    {
        EnsureNotBuilt();
        _isBuilt = true;

        return _services.BuildServiceProvider();
    }

    private void EnsureNotBuilt()
    {
        if (_isBuilt)
            throw new InvalidOperationException("ServiceProvider is already built");
    }
}
