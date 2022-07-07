using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiconnectorGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ApiConnectors_IdentityApiConnectorId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ApiConnectors_IdentityApiConnectorId: return $"/identity/apiConnectors/{IdentityApiConnectorId}";
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
        public string IdentityApiConnectorId { get; set; }
    }
    public partial class IdentityapiconnectorGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorGetResponse> IdentityapiconnectorGetAsync()
        {
            var p = new IdentityapiconnectorGetParameter();
            return await this.SendAsync<IdentityapiconnectorGetParameter, IdentityapiconnectorGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorGetResponse> IdentityapiconnectorGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiconnectorGetParameter();
            return await this.SendAsync<IdentityapiconnectorGetParameter, IdentityapiconnectorGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorGetResponse> IdentityapiconnectorGetAsync(IdentityapiconnectorGetParameter parameter)
        {
            return await this.SendAsync<IdentityapiconnectorGetParameter, IdentityapiconnectorGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorGetResponse> IdentityapiconnectorGetAsync(IdentityapiconnectorGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiconnectorGetParameter, IdentityapiconnectorGetResponse>(parameter, cancellationToken);
        }
    }
}
