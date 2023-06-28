using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestSchemeEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestSchemeEnricher(string propertyName = "RequestScheme") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var scheme = httpContext?.Request?.Scheme;
        if (scheme == null) return;
        var property = propertyFactory.CreateProperty(_propertyName, scheme);
        logEvent.AddOrUpdateProperty(property);
    }
}