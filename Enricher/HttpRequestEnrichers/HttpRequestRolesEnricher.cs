using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestRolesEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestRolesEnricher(string propertyName = "Role", bool isGetSingleRole = false) {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var roleClaim = httpContext?.User?.Claims?.Where(x => x.Type == ClaimTypes.Role).ToList();
        if (roleClaim == null) return;
        if (roleClaim.Count == 0) return;
        var rolesString = string.Join(",", roleClaim.Select(x => x.Value));
        var property = propertyFactory.CreateProperty(_propertyName, rolesString);
        logEvent.AddOrUpdateProperty(property);
    }
}