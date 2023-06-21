using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class ThreadIdEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public ThreadIdEnricher(string propertyName) {
        _propertyName = propertyName;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        var property = propertyFactory.CreateProperty(_propertyName, threadId);
        logEvent.AddOrUpdateProperty(property);
    }
}