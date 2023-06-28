using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestPathEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestPathEnricher(string propertyName = "RequestPath") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var uriPath = httpContext?.Request?.Path.Value;
        if (uriPath == null) return;
        var property = propertyFactory.CreateProperty(_propertyName, uriPath ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}