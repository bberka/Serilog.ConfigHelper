using System.Net;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class HostIpAddressEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private static string? _hostIpAddress;

    public HostIpAddressEnricher(string propertyName = "HostIpAddress") {
        _propertyName = propertyName;
        _hostIpAddress ??= GetHostIpAddress();
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var property = propertyFactory.CreateProperty(_propertyName, _hostIpAddress);
        logEvent.AddOrUpdateProperty(property);
    }
    

    private static string GetHostIpAddress() {
        var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        var ipAddress = ipHostInfo.AddressList[0];
        return ipAddress.ToString();
    }
}
