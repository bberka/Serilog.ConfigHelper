using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class RoleEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public RoleEnricher(string propertyName,bool isGetSingleRole = false) {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var roleClaim = httpContext?.User?.Claims?.Where(x => x.Type == ClaimTypes.Role).ToList();
        var rolesString = string.Join(",", roleClaim?.Select(x => x.Value) ?? Array.Empty<string>());
        var property = propertyFactory.CreateProperty(_propertyName, rolesString ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}