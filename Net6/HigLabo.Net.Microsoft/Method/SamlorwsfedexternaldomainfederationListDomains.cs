using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SamlorwsfedexternaldomainfederationListDomainsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SamlOrWsFedExternalDomainFederationID { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_FederationConfigurations_MicrosoftgraphsamlOrWsFedExternalDomainFederation_SamlOrWsFedExternalDomainFederationID_Domains: return $"/directory/federationConfigurations/microsoft.graph.samlOrWsFedExternalDomainFederation/{SamlOrWsFedExternalDomainFederationID}/domains";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_FederationConfigurations_MicrosoftgraphsamlOrWsFedExternalDomainFederation_SamlOrWsFedExternalDomainFederationID_Domains,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class SamlorwsfedexternaldomainfederationListDomainsResponse : RestApiResponse
    {
        public ExternalDomainName[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationListDomainsParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationListDomainsParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync(SamlorwsfedexternaldomainfederationListDomainsParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync(SamlorwsfedexternaldomainfederationListDomainsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(parameter, cancellationToken);
        }
    }
}
