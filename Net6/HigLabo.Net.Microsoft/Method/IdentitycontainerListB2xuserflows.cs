using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentitycontainerListB2xuserflowsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows: return $"/identity/b2xUserFlows";
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
    public partial class IdentitycontainerListB2xuserflowsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/b2xidentityuserflow?view=graph-rest-1.0
        /// </summary>
        public partial class B2xIdentityUserFlow
        {
            public string? Id { get; set; }
            public string? UserFlowType { get; set; }
            public Single? UserFlowTypeVersion { get; set; }
            public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
        }

        public B2xIdentityUserFlow[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xuserflowsResponse> IdentitycontainerListB2xuserflowsAsync()
        {
            var p = new IdentitycontainerListB2xuserflowsParameter();
            return await this.SendAsync<IdentitycontainerListB2xuserflowsParameter, IdentitycontainerListB2xuserflowsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xuserflowsResponse> IdentitycontainerListB2xuserflowsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerListB2xuserflowsParameter();
            return await this.SendAsync<IdentitycontainerListB2xuserflowsParameter, IdentitycontainerListB2xuserflowsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xuserflowsResponse> IdentitycontainerListB2xuserflowsAsync(IdentitycontainerListB2xuserflowsParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerListB2xuserflowsParameter, IdentitycontainerListB2xuserflowsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xuserflowsResponse> IdentitycontainerListB2xuserflowsAsync(IdentitycontainerListB2xuserflowsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerListB2xuserflowsParameter, IdentitycontainerListB2xuserflowsResponse>(parameter, cancellationToken);
        }
    }
}
