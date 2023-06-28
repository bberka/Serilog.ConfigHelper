using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestMethodEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestMethodEnricher(string propertyName = "RequestMethod") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var method = httpContext?.Request?.Method;
        if(method == null) return;
        var property = propertyFactory.CreateProperty(_propertyName, method);
        logEvent.AddOrUpdateProperty(property);
    }
}