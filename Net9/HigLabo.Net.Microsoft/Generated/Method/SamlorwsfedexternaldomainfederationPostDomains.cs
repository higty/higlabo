using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
/// </summary>
public partial class SamlorwsfedexternaldomainfederationPostDomainsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SamlOrWsFedExternalDomainFederationID { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID_MicrosoftgraphsamlOrWsFedExternalDomainFederation_Domains: return $"/directory/federationConfigurations/{SamlOrWsFedExternalDomainFederationID}/microsoft.graph.samlOrWsFedExternalDomainFederation/domains";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Directory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID_MicrosoftgraphsamlOrWsFedExternalDomainFederation_Domains,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Id { get; set; }
}
public partial class SamlorwsfedexternaldomainfederationPostDomainsResponse : RestApiResponse
{
    public string? Id { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync()
    {
        var p = new SamlorwsfedexternaldomainfederationPostDomainsParameter();
        return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync(CancellationToken cancellationToken)
    {
        var p = new SamlorwsfedexternaldomainfederationPostDomainsParameter();
        return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync(SamlorwsfedexternaldomainfederationPostDomainsParameter parameter)
    {
        return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync(SamlorwsfedexternaldomainfederationPostDomainsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(parameter, cancellationToken);
    }
}
