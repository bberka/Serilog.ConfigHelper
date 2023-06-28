using System.Net.NetworkInformation;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class MacAddressEnricher : ILogEventEnricher
{
    private readonly bool _isGetOnlyActive;
    private readonly bool _isGetSingle;
    private readonly string _propertyName;

    private static string _macAddress;
    public MacAddressEnricher(string propertyName = "MacAddress", bool isGetSingle = true, bool isGetOnlyActive = true) {
        _propertyName = propertyName;
        _isGetSingle = isGetSingle;
        _isGetOnlyActive = isGetOnlyActive;
        _macAddress ??= GetMacAddress();
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var property = propertyFactory.CreateProperty(_propertyName, _macAddress);
        logEvent.AddOrUpdateProperty(property);
    }

    private string GetMacAddress() {
        var networks = NetworkInterface.GetAllNetworkInterfaces();
        if (_isGetOnlyActive)
            networks = networks
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .ToArray();
        var macAddressList = networks.Select(network => network.GetPhysicalAddress().ToString()).Where(macAddress => !string.IsNullOrEmpty(macAddress)).ToList();
        if (_isGetSingle) return macAddressList.FirstOrDefault() ?? string.Empty;
        return string.Join(",", macAddressList);
    }
}