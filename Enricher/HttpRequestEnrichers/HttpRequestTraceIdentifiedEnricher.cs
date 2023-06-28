using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestTraceIdentifiedEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestTraceIdentifiedEnricher(string propertyName = "RequestId") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var traceId = httpContext?.TraceIdentifier;
        if (traceId == null) return;
        var property = propertyFactory.CreateProperty(_propertyName, traceId);
        logEvent.AddOrUpdateProperty(property);
    }
}