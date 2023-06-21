using System.Net.NetworkInformation;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class MacAddressEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private readonly bool _isGetSingle;
    private readonly bool _isGetOnlyActive;

    public MacAddressEnricher(string propertyName, bool isGetSingle = true, bool isGetOnlyActive = true) {
        _propertyName = propertyName;
        _isGetSingle = isGetSingle;
        _isGetOnlyActive = isGetOnlyActive;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var macAddressString = GetMacAddress();
        var property = propertyFactory.CreateProperty(_propertyName, macAddressString);
        logEvent.AddOrUpdateProperty(property);
    }

    private string GetMacAddress() {
        var networks = NetworkInterface.GetAllNetworkInterfaces();
        if (_isGetOnlyActive) {
            networks = networks
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .ToArray();
        }

        var macAddressList = networks.Select(network => network.GetPhysicalAddress().ToString()).Where(macAddress => !string.IsNullOrEmpty(macAddress)).ToList();
        if (_isGetSingle) {
            return macAddressList.FirstOrDefault();
        }
        return string.Join(",", macAddressList);
    }
}