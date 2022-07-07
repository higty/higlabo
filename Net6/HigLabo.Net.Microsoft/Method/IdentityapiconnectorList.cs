using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiconnectorListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ApiConnectors_,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ApiConnectors_: return $"/identity/apiConnectors/";
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
    public partial class IdentityapiconnectorListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/identityapiconnector?view=graph-rest-1.0
        /// </summary>
        public partial class IdentityApiConnector
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? TargetUrl { get; set; }
            public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
        }

        public IdentityApiConnector[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorListResponse> IdentityapiconnectorListAsync()
        {
            var p = new IdentityapiconnectorListParameter();
            return await this.SendAsync<IdentityapiconnectorListParameter, IdentityapiconnectorListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorListResponse> IdentityapiconnectorListAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiconnectorListParameter();
            return await this.SendAsync<IdentityapiconnectorListParameter, IdentityapiconnectorListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorListResponse> IdentityapiconnectorListAsync(IdentityapiconnectorListParameter parameter)
        {
            return await this.SendAsync<IdentityapiconnectorListParameter, IdentityapiconnectorListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorListResponse> IdentityapiconnectorListAsync(IdentityapiconnectorListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiconnectorListParameter, IdentityapiconnectorListResponse>(parameter, cancellationToken);
        }
    }
}
