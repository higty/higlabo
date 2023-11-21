using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
    /// </summary>
    public partial class IdentitycontainerPostB2xUserflowsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows: return $"/identity/b2xUserFlows";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_B2xUserFlows,
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
        public string? UserFlowType { get; set; }
        public float? UserFlowTypeVersion { get; set; }
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
        public IdentityProvider[]? IdentityProviders { get; set; }
        public UserFlowLanguageConfiguration[]? Languages { get; set; }
        public IdentityUserFlowAttributeAssignment[]? UserAttributeAssignments { get; set; }
    }
    public partial class IdentitycontainerPostB2xUserflowsResponse : RestApiResponse
    {
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
        public string? Id { get; set; }
        public string? UserFlowType { get; set; }
        public Single? UserFlowTypeVersion { get; set; }
        public IdentityProvider[]? IdentityProviders { get; set; }
        public UserFlowLanguageConfiguration[]? Languages { get; set; }
        public IdentityUserFlowAttributeAssignment[]? UserAttributeAssignments { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostB2xUserflowsResponse> IdentitycontainerPostB2xUserflowsAsync()
        {
            var p = new IdentitycontainerPostB2xUserflowsParameter();
            return await this.SendAsync<IdentitycontainerPostB2xUserflowsParameter, IdentitycontainerPostB2xUserflowsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostB2xUserflowsResponse> IdentitycontainerPostB2xUserflowsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerPostB2xUserflowsParameter();
            return await this.SendAsync<IdentitycontainerPostB2xUserflowsParameter, IdentitycontainerPostB2xUserflowsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostB2xUserflowsResponse> IdentitycontainerPostB2xUserflowsAsync(IdentitycontainerPostB2xUserflowsParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerPostB2xUserflowsParameter, IdentitycontainerPostB2xUserflowsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitycontainerPostB2xUserflowsResponse> IdentitycontainerPostB2xUserflowsAsync(IdentitycontainerPostB2xUserflowsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerPostB2xUserflowsParameter, IdentitycontainerPostB2xUserflowsResponse>(parameter, cancellationToken);
        }
    }
}
