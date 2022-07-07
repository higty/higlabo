using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SamlorwsfedexternaldomainfederationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SamlorwsfedexternaldomainfederationGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationGetResponse> SamlorwsfedexternaldomainfederationGetAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationGetParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationGetParameter, SamlorwsfedexternaldomainfederationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationGetResponse> SamlorwsfedexternaldomainfederationGetAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationGetParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationGetParameter, SamlorwsfedexternaldomainfederationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationGetResponse> SamlorwsfedexternaldomainfederationGetAsync(SamlorwsfedexternaldomainfederationGetParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationGetParameter, SamlorwsfedexternaldomainfederationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationGetResponse> SamlorwsfedexternaldomainfederationGetAsync(SamlorwsfedexternaldomainfederationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationGetParameter, SamlorwsfedexternaldomainfederationGetResponse>(parameter, cancellationToken);
        }
    }
}
