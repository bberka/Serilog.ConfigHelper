using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class MachineNameEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public MachineNameEnricher(string propertyName = "MachineName") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var machineName = Environment.MachineName;
        var property = propertyFactory.CreateProperty(_propertyName, machineName);
        logEvent.AddOrUpdateProperty(property);
    }
}