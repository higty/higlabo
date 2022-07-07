using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentitycontainerPostB2xuserflowsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? UserFlowType { get; set; }
        public float? UserFlowTypeVersion { get; set; }
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
    }
    public partial class IdentitycontainerPostB2xuserflowsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserFlowType { get; set; }
        public Single? UserFlowTypeVersion { get; set; }
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostB2xuserflowsResponse> IdentitycontainerPostB2xuserflowsAsync()
        {
            var p = new IdentitycontainerPostB2xuserflowsParameter();
            return await this.SendAsync<IdentitycontainerPostB2xuserflowsParameter, IdentitycontainerPostB2xuserflowsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostB2xuserflowsResponse> IdentitycontainerPostB2xuserflowsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerPostB2xuserflowsParameter();
            return await this.SendAsync<IdentitycontainerPostB2xuserflowsParameter, IdentitycontainerPostB2xuserflowsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostB2xuserflowsResponse> IdentitycontainerPostB2xuserflowsAsync(IdentitycontainerPostB2xuserflowsParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerPostB2xuserflowsParameter, IdentitycontainerPostB2xuserflowsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerPostB2xuserflowsResponse> IdentitycontainerPostB2xuserflowsAsync(IdentitycontainerPostB2xuserflowsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerPostB2xuserflowsParameter, IdentitycontainerPostB2xuserflowsResponse>(parameter, cancellationToken);
        }
    }
}
