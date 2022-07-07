using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SamlorwsfedexternaldomainfederationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_FederationConfigurations_GraphsamlOrWsFedExternalDomainFederation,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_FederationConfigurations_GraphsamlOrWsFedExternalDomainFederation: return $"/directory/federationConfigurations/graph.samlOrWsFedExternalDomainFederation";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class SamlorwsfedexternaldomainfederationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/samlorwsfedexternaldomainfederation?view=graph-rest-1.0
        /// </summary>
        public partial class SamlOrWsFedExternalDomainFederation
        {
            public enum SamlOrWsFedExternalDomainFederationAuthenticationProtocol
            {
                WsFed,
                Saml,
                UnknownFutureValue,
            }

            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? IssuerUri { get; set; }
            public string? MetadataExchangeUri { get; set; }
            public string? PassiveSignInUri { get; set; }
            public SamlOrWsFedExternalDomainFederationAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
            public string? SigningCertificate { get; set; }
        }

        public SamlOrWsFedExternalDomainFederation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationListParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationListParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync(SamlorwsfedexternaldomainfederationListParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync(SamlorwsfedexternaldomainfederationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(parameter, cancellationToken);
        }
    }
}
