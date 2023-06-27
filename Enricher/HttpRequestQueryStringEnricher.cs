using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HttpRequestQueryStringEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestQueryStringEnricher(string propertyName = "RequestQueryString") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var queryString = httpContext?.Request?.QueryString;
        var queryStringValue = queryString.HasValue ? queryString.Value.ToString() : "-";
        var property = propertyFactory.CreateProperty(_propertyName, queryStringValue);
        logEvent.AddOrUpdateProperty(property);
    }
}