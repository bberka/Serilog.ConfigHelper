using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class EnvironmentVariableEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private readonly string _environmentVariableName;

    public EnvironmentVariableEnricher(string propertyName,string environmentVariableName) {
        _propertyName = propertyName;
        _environmentVariableName = environmentVariableName;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var environment = Environment.GetEnvironmentVariable(_environmentVariableName);
        var property = propertyFactory.CreateProperty(_propertyName, environment ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}