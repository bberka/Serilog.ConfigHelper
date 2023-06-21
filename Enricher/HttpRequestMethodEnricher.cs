using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HttpRequestMethodEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestMethodEnricher(string propertyName) {
        _propertyName = propertyName;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var method = httpContext?.Request?.Method;
        var property = propertyFactory.CreateProperty(_propertyName, method ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}