using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestClaimEnricher : ILogEventEnricher
{
    private readonly string _claimType;
    private readonly string _propertyName;

    public HttpRequestClaimEnricher(string propertyName, string claimType) {
        _propertyName = propertyName;
        _claimType = claimType;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var claim = new HttpContextAccessor().HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == _claimType);
        if (claim == null) return;
        var claimProperty = new LogEventProperty(_propertyName, new ScalarValue(claim.Value));
        logEvent.AddOrUpdateProperty(claimProperty);
    }
}