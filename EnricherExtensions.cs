// using Serilog.ConfigHelper.Enricher;
// using Serilog.Configuration;
//
// namespace Serilog.ConfigHelper;
//
// public static class EnricherExtensions
// {
//     public static LoggerConfiguration WithClaimEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, string claimType) {
//         var claimEnricher = new ClaimEnricher(propertyName, claimType);
//         return enrich.With(claimEnricher);
//     }
//
//     public static LoggerConfiguration WithIpAddressEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "IpAddress", string realIpHeader = "") {
//         var ipAddressEnricher = new HttpRequestIpAddressEnricher(propertyName, realIpHeader);
//         return enrich.With(ipAddressEnricher);
//     }
//
//     public static LoggerConfiguration WithRequestPathEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "RequestPath") {
//         var uriPathEnricher = new HttpRequestPathEnricher(propertyName);
//         return enrich.With(uriPathEnricher);
//     }
//
//     public static LoggerConfiguration WithUserNameEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "UserName") {
//         var userNameEnricher = new AuthenticatedUserNameEnricher(propertyName);
//         return enrich.With(userNameEnricher);
//     }
//
//     public static LoggerConfiguration WithRoleEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "Role", bool isGetSingleRole = false) {
//         var roleEnricher = new RoleEnricher(propertyName, isGetSingleRole);
//         return enrich.With(roleEnricher);
//     }
//
//     public static LoggerConfiguration WithMachineNameEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "MachineName") {
//         var machineNameEnricher = new MachineNameEnricher(propertyName);
//         return enrich.With(machineNameEnricher);
//     }
//
//     public static LoggerConfiguration WithEnvironmentVariableEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, string environmentVariableName) {
//         var environmentEnricher = new EnvironmentVariableEnricher(propertyName, environmentVariableName);
//         return enrich.With(environmentEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestIdEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "HttpRequestId") {
//         var httpRequestEnricher = new HttpRequestIdEnricher(propertyName);
//         return enrich.With(httpRequestEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestHeaderEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, string headerName) {
//         var httpRequestHeaderEnricher = new HttpRequestHeaderEnricher(propertyName, headerName);
//         return enrich.With(httpRequestHeaderEnricher);
//     }
//
//     public static LoggerConfiguration WithThreadIdEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "ThreadId") {
//         var threadIdEnricher = new ThreadIdEnricher(propertyName);
//         return enrich.With(threadIdEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestMethodEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "HttpMethod") {
//         var httpRequestMethodEnricher = new HttpRequestMethodEnricher(propertyName);
//         return enrich.With(httpRequestMethodEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestProtocolEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "HttpProtocol") {
//         var httpRequestProtocolEnricher = new HttpRequestProtocolEnricher(propertyName);
//         return enrich.With(httpRequestProtocolEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestUserAgentEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName = "UserAgent") {
//         var httpRequestProtocolEnricher = new HttpRequestUserAgentEnricher(propertyName);
//         return enrich.With(httpRequestProtocolEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestSchemeEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
//         var httpRequestSchemeEnricher = new HttpRequestSchemeEnricher(propertyName);
//         return enrich.With(httpRequestSchemeEnricher);
//     }
//
//     public static LoggerConfiguration WithHttpRequestQueryStringEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
//         var httpRequestQueryStringEnricher = new HttpRequestQueryStringEnricher(propertyName);
//         return enrich.With(httpRequestQueryStringEnricher);
//     }
//
//     public static LoggerConfiguration WithMachineGuidEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
//         var machineGuidEnricher = new MachineGuidEnricher(propertyName);
//         return enrich.With(machineGuidEnricher);
//     }
//
//     public static LoggerConfiguration WithMacAddressEnricher(
//         this LoggerEnrichmentConfiguration enrich,
//         string propertyName,
//         bool isGetSingle = true,
//         bool isGetOnlyActive = true) {
//         var machineGuidEnricher = new MacAddressEnricher(propertyName, isGetSingle, isGetOnlyActive);
//         return enrich.With(machineGuidEnricher);
//     }
// }

