using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Extensions.Serilog;

public static class LoggerExtensions
{
    public static ILogger RegisterTo(this ILogger logger, IServiceCollection services)
    {
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(logger, true);
        });

        return logger;
    }
}
