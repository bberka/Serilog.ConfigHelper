using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

/// <summary>
///     Enriches Serilog messages with the all header values in current HttpRequest.
/// </summary>
public class HttpRequestAllHeadersEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var context = new HttpContextAccessor().HttpContext;
        if (context == null) {
            Trace.WriteLine("You must add the HttpContextAccessor to the DI container.");
            return;
        }

        var headers = context.Request.Headers;
        foreach (var item in headers) {
            var property = propertyFactory.CreateProperty("Header:" + item.Key, item.Value);
            logEvent.AddOrUpdateProperty(property);
        }
    }
}