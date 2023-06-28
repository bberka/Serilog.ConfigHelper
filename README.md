# Serilog.ConfigHelper Library

Provides various built-in enrichers for Serilog and a TemplateBuilder to help you build Serilog templates easily.

## Installation

You can install the package via NuGet:

```
Install-Package Serilog.ConfigHelper
```

## Usage

### TemplateBuilder

Easily build Serilog templates with the TemplateBuilder. The TemplateBuilder provides methods to add the following
elements to the template:

- Timestamp
- Level
- Message
- Exception
- Property
- NewLine

_The order which the Add methods used is the order which the elements will appear in the template._

Creating default template builder

```csharp
var template = new TemplateBuilder()
    .AddTimestamp()
    .AddLevel()
    .AddMessage()
    .AddException()
    .Build();
```

Creating template with properties

```csharp
var template = new TemplateBuilder()
    .AddTimestamp()
    .AddLevel()
    .AddProperty("ThreadId") // Add property with name
    .AddProperty("MachineName",true) // Add property with name inside square brackets
    .AddMessage()
    .AddException()
    .Build();
```

### Enrichers

Built-in enrichers for Serilog.
You can change the default PropertyName for each enricher in constructor.

#### Example usage of enrichers

```csharp
var logger = new LoggerConfiguration()
    .Enrich.With(new ThreadIdEnricher())
    .Enrich.With(new TimeZoneEnricher())
    .Enrich.With(new ClaimEnricher("ClaimName"))
    .Enrich.With(new HttpRequestUserIdentityNameEnricher())
    .Enrich.With(new HttpRequestAllHeadersEnricher())//Property name will be like this: "Header:HeaderName"
    .CreateLogger();
```

#### Common Enrichers

Enriches log events with device or environment information.

Following enrichers are available:

- OSVersionEnricher
    - Adds the OS version to the log event properties.
- DiskUUIDEnricher
    - Adds the disk UUID to the log event properties.
- ThreadIdEnricher
    - Adds the current thread id to the log event properties.
- TimeZoneEnricher
    - Adds the current time zone to the log event properties.
- HostIpAddressEnricher
    - Adds the host ip address to the log event properties.
- EnvironmentVariableEnricher
    - Adds the environment variable to the log event properties.
- MacAddressEnricher
    - Adds the mac address to the log event properties.
- MachineNameEnricher
    - Adds the machine name to the log event properties.
- MachineGuidEnricher
    - Adds the machine guid to the log event properties.
- StackTraceEnricher _(For debugging purposes)_
    - Adds the stack trace to the log event properties. This is a heavy task and not performant. This should not be used
      in production.

#### AspNetCore HttpRequest Enrichers

Enriches log events with information from the current HttpContext.
You must add HttpContextAccessor to the DI container.

Following enrichers are available:

- HttpRequestClaimEnricher
    - Adds the specified claim from current HttpContext to the log event properties.
- HttpRequestUserIdentityNameEnricher
    - Adds the user identity name from current HttpContext to the log event properties.
- HttpRequestAllHeadersEnricher
    - Adds all headers from current HttpContext.Request to the log event properties.
- HttpRequestHeaderEnricher
    - Adds the specified header from current HttpContext.Request to the log event properties.
- HttpRequestIdEnricher
    - Adds the request id from current HttpContext.Request to the log event properties.
- HttpRequestMethodEnricher
    - Adds the request method from current HttpContext.Request to the log event properties.
- HttpRequestPathEnricher
    - Adds the request path from current HttpContext.Request to the log event properties.
- HttpRequestProtocolEnricher
    - Adds the request protocol from current HttpContext.Request to the log event properties.
- HttpRequestQueryStringEnricher
    - Adds the request query string from current HttpContext.Request to the log event properties.
- HttpRequestSchemeEnricher
    - Adds the request scheme from current HttpContext.Request to the log event properties.
- HttpRequestStatusCodeEnricher
    - Adds the request status code from current HttpContext.Response to the log event properties.
- HttpRequestTraceIdentifierEnricher
    - Adds the request trace identifier from current HttpContext.Request to the log event properties.
- HttpRequestUserAgentEnricher
    - Adds the request user agent from current HttpContext.Request to the log event properties.
- HttpRequestRolesEnricher
    - Adds the request roles from current HttpContext.User to the log event properties.



