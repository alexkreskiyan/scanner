using Extensions.Serilog.Internal;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace Extensions.Serilog;

public static class LogBuilder
{
    public const string OutputTemplate =
        "[{Timestamp:HH:mm:ss.fff}] {Level:u3} [{ThreadId}] {Message:lj} {Properties:j}{NewLine}{Exception}";

    public static LoggerConfiguration DefaultConfiguration()
    {
        return new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Is(LogEventLevel.Verbose)
            .Enrich.With(new RemovePropertiesEnricher("SourceContext"))
            .Enrich.FromLogContext()
            .Enrich.WithCorrelationId()
            .Enrich.WithExceptionDetails()
            .Enrich.WithThreadId()
            .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"));
    }
}
