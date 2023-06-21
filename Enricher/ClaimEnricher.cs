using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class ClaimEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private readonly string _claimType;

    public ClaimEnricher(string propertyName,string claimType) {
        _propertyName = propertyName;
        _claimType = claimType;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var claim = new HttpContextAccessor().HttpContext.User.Claims.FirstOrDefault(x => x.Type == _claimType);
        if (claim == null) throw new NotImplementedException();
        var claimProperty = new LogEventProperty(_propertyName, new ScalarValue(claim.Value));
        logEvent.AddOrUpdateProperty(claimProperty);
    }
}