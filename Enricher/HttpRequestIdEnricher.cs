using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HttpRequestIdEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestIdEnricher(string propertyName) {
        _propertyName = propertyName;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var requestId = httpContext?.TraceIdentifier;
        var property = propertyFactory.CreateProperty(_propertyName, requestId ?? "-");
        logEvent.AddOrUpdateProperty(property);
        
    }
}