using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

internal class SourceEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var t = new StackTrace(true);
        var frame = t.GetFrame(8);
        var method = frame?.GetMethod();
        var cls = method?.ReflectedType?.Name;
        var property = propertyFactory.CreateProperty("Source", $"{cls}.{method?.Name}");
        logEvent.AddOrUpdateProperty(property);
    }
}