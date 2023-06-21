using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HttpRequestHeaderEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private readonly string _headerName;

    public HttpRequestHeaderEnricher(string propertyName, string headerName) {
        _propertyName = propertyName;
        _headerName = headerName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var header = httpContext?.Request?.Headers[_headerName];
        var property = propertyFactory.CreateProperty(_propertyName, header ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}