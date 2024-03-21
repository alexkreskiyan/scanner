using Serilog.Core;
using Serilog.Events;

namespace Extensions.Serilog.Internal;

internal class RemovePropertiesEnricher : ILogEventEnricher
{
    private readonly string[] _propertyNames;

    public RemovePropertiesEnricher(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        foreach (var propertyName in _propertyNames)
            logEvent.RemovePropertyIfPresent(propertyName);
    }
}
