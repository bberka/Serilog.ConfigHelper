﻿using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher;

public class AuthenticatedUserNameEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public AuthenticatedUserNameEnricher(string propertyName = "UserName") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var userName = httpContext?.User?.Identity?.Name;
        var property = propertyFactory.CreateProperty(_propertyName, userName ?? "-");
        logEvent.AddOrUpdateProperty(property);
    }
}