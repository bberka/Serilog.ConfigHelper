using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestProtocolEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestProtocolEnricher(string propertyName = "RequestProtocol") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var protocol = httpContext?.Request?.Protocol;
        if(protocol == null) return;
        var property = propertyFactory.CreateProperty(_propertyName, protocol ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}