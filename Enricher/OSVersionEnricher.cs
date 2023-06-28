using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class OSVersionEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public OSVersionEnricher(string propertyName = "OSVersion") {
        _propertyName = propertyName;
    }


    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var osVersion = Environment.OSVersion.ToString();
        var property = propertyFactory.CreateProperty(_propertyName, osVersion);
        logEvent.AddOrUpdateProperty(property);
    }
}