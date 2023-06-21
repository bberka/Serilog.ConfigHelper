using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

internal class IpAddressEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private readonly string _realIpHeader;

    public IpAddressEnricher(string propertyName, string realIpHeader) {
        _propertyName = propertyName;
        _realIpHeader = realIpHeader;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var remoteIpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();
        if (!string.IsNullOrEmpty(_realIpHeader)) {
            var realIp = httpContext?.Request?.Headers[_realIpHeader].ToString();
            if (!string.IsNullOrEmpty(realIp)) remoteIpAddress = realIp;
        }
        if (string.IsNullOrEmpty(remoteIpAddress)) remoteIpAddress = "-";
        var property = propertyFactory.CreateProperty(_propertyName, remoteIpAddress);
        logEvent.AddOrUpdateProperty(property);
    }
}