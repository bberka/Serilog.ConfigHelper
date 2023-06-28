using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class DiskUUIDEnricher : ILogEventEnricher
{
    private readonly string _propertyName;
    private static string? _diskUUID;

    public DiskUUIDEnricher(string propertyName = "DiskUUID") {
        _propertyName = propertyName;
        _diskUUID ??= GetDiskUUID();
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var property = propertyFactory.CreateProperty(_propertyName, _diskUUID);
        logEvent.AddOrUpdateProperty(property);
    }
    private static string GetDiskUUID() {
        const string run = "get-wmiobject Win32_ComputerSystemProduct  | Select-Object -ExpandProperty UUID";
        var oProcess = new Process();
        var oStartInfo = new ProcessStartInfo("powershell.exe", run);
        oStartInfo.UseShellExecute = false;
        oStartInfo.RedirectStandardInput = true;
        oStartInfo.RedirectStandardOutput = true;
        oStartInfo.CreateNoWindow = true;
        oProcess.StartInfo = oStartInfo;
        oProcess.Start();
        oProcess.WaitForExit();
        var result = oProcess.StandardOutput.ReadToEnd();
        return result.Replace(" ","").ReplaceLineEndings("");
    }
}