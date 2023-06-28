﻿using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.ConfigHelper.Enricher.HttpRequestEnrichers;

public class HttpRequestUserIdentityNameEnricher : ILogEventEnricher
{
    private readonly string _propertyName;

    public HttpRequestUserIdentityNameEnricher(string propertyName = "UserName") {
        _propertyName = propertyName;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory) {
        var httpContext = new HttpContextAccessor().HttpContext;
        var userName = httpContext?.User?.Identity?.Name;
        if (userName == null) return;
        var property = propertyFactory.CreateProperty(_propertyName, userName);
        logEvent.AddOrUpdateProperty(property);
    }
}