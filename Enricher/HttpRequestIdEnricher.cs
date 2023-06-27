using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HttpRequestIdEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestIdEnricher(string propertyName = "RequestId") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var requestId = httpContext?.Connection?.Id;
        var property = propertyFactory.CreateProperty(_propertyName, requestId ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}