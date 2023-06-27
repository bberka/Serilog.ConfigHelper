using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HttpRequestSchemeEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestSchemeEnricher(string propertyName = "RequestScheme") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var scheme = httpContext?.Request?.Scheme;
        var property = propertyFactory.CreateProperty(_propertyName, scheme ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}