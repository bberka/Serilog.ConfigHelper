using Serilog.ConfigHelper.Enricher;
using Serilog.Configuration;

namespace Serilog.ConfigHelper;

public static class EnricherExtensions
{
    public static LoggerConfiguration AddClaimEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName,string claimType)
    {
        var claimEnricher = new ClaimEnricher(propertyName,claimType);
        return enrich.With(claimEnricher);
    }

    public static LoggerConfiguration AddIpAddressEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, string realIpHeader = "") {
        var ipAddressEnricher = new IpAddressEnricher(propertyName, realIpHeader);
        return enrich.With(ipAddressEnricher);
    }
    
    public static LoggerConfiguration AddRequestPathEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var uriPathEnricher = new RequestPathEnricher(propertyName);
        return enrich.With(uriPathEnricher);
    }
    
    public static LoggerConfiguration AddUserNameEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var userNameEnricher = new UserNameEnricher(propertyName);
        return enrich.With(userNameEnricher);
    }
    public static LoggerConfiguration AddRoleEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, bool isGetSingleRole = false) {
        var roleEnricher = new RoleEnricher(propertyName, isGetSingleRole);
        return enrich.With(roleEnricher);
    }
    
    public static LoggerConfiguration AddMachineNameEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var machineNameEnricher = new MachineNameEnricher(propertyName);
        return enrich.With(machineNameEnricher);
    }
    
    public static LoggerConfiguration AddEnvironmentVariableEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, string environmentVariableName) {
        var environmentEnricher = new EnvironmentVariableEnricher(propertyName,environmentVariableName);
        return enrich.With(environmentEnricher);
    }
    
    public static LoggerConfiguration AddHttpRequestIdEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var httpRequestEnricher = new HttpRequestIdEnricher(propertyName);
        return enrich.With(httpRequestEnricher);
    }
    
    public static LoggerConfiguration AddHttpRequestHeaderEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName, string headerName) {
        var httpRequestHeaderEnricher = new HttpRequestHeaderEnricher(propertyName,headerName);
        return enrich.With(httpRequestHeaderEnricher);
    }

    public static LoggerConfiguration AddThreadIdEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var threadIdEnricher = new ThreadIdEnricher(propertyName);
        return enrich.With(threadIdEnricher);
    }
    public static LoggerConfiguration AddHttpRequestMethodEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var httpRequestMethodEnricher = new HttpRequestMethodEnricher(propertyName);
        return enrich.With(httpRequestMethodEnricher);
    }
    
    public static LoggerConfiguration AddHttpRequestProtocolEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var httpRequestProtocolEnricher = new HttpRequestProtocolEnricher(propertyName);
        return enrich.With(httpRequestProtocolEnricher);
    }
    
    public static LoggerConfiguration AddHttpRequestSchemeEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var httpRequestSchemeEnricher = new HttpRequestSchemeEnricher(propertyName);
        return enrich.With(httpRequestSchemeEnricher);
    }
    
    public static LoggerConfiguration AddHttpRequestQueryStringEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var httpRequestQueryStringEnricher = new HttpRequestQueryStringEnricher(propertyName);
        return enrich.With(httpRequestQueryStringEnricher);
    }
    
    public static LoggerConfiguration AddMachineGuidEnricher(this LoggerEnrichmentConfiguration enrich, string propertyName) {
        var machineGuidEnricher = new MachineGuidEnricher(propertyName);
        return enrich.With(machineGuidEnricher);
    }
    public static LoggerConfiguration AddMacAddressEnricher(
        this LoggerEnrichmentConfiguration enrich, 
        string propertyName,
        bool isGetSingle = true, 
        bool isGetOnlyActive = true) {
        var machineGuidEnricher = new MacAddressEnricher(propertyName,isGetSingle, isGetOnlyActive);
        return enrich.With(machineGuidEnricher);
    }
    
}