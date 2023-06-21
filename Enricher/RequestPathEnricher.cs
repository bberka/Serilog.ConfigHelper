using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;


internal class RequestPathEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public RequestPathEnricher(string propertyName) {
        _propertyName = propertyName;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var uriPath = httpContext?.Request?.Path.Value;
        var property = propertyFactory.CreateProperty(_propertyName, uriPath ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}

