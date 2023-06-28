using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class TimeZoneEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public TimeZoneEnricher(string propertyName = "TimeZone") {
        _propertyName = propertyName;
    }
        
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var timeZone = TimeZoneInfo.Local;
        var property = propertyFactory.CreateProperty(_propertyName, timeZone);
        logEvent.AddOrUpdateProperty(property);
    }
}