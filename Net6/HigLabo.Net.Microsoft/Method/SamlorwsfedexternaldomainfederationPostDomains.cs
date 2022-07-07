using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SamlorwsfedexternaldomainfederationPostDomainsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID_MicrosoftgraphsamlOrWsFedExternalDomainFederation_Domains,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_FederationConfigurations_SamlOrWsFedExternalDomainFederationID_MicrosoftgraphsamlOrWsFedExternalDomainFederation_Domains: return $"/directory/federationConfigurations/{SamlOrWsFedExternalDomainFederationID}/microsoft.graph.samlOrWsFedExternalDomainFederation/domains";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string SamlOrWsFedExternalDomainFederationID { get; set; }
    }
    public partial class SamlorwsfedexternaldomainfederationPostDomainsResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationPostDomainsParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationPostDomainsParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync(SamlorwsfedexternaldomainfederationPostDomainsParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationPostDomainsResponse> SamlorwsfedexternaldomainfederationPostDomainsAsync(SamlorwsfedexternaldomainfederationPostDomainsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationPostDomainsParameter, SamlorwsfedexternaldomainfederationPostDomainsResponse>(parameter, cancellationToken);
        }
    }
}
