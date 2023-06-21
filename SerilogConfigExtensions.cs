using Serilog.Events;

namespace Serilog.ConfigHelper;

public static class SerilogConfigExtensions
{
    public static LoggerConfiguration SetLogLevel(this LoggerConfiguration config, LogEventLevel level, LogEventLevel debugLevel = LogEventLevel.Verbose) {
        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        config.MinimumLevel.Is(isDevelopment ? debugLevel : level);
        return config;
    }
}