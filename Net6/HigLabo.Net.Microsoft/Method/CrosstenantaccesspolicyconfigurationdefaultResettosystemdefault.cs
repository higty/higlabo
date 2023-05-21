using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Default_ResetToSystemDefault: return $"/policies/crossTenantAccessPolicy/default/resetToSystemDefault";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Default_ResetToSystemDefault,
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
    }
    public partial class CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse> CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultAsync()
        {
            var p = new CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter, CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse> CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter, CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse> CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultAsync(CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter, CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse> CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultAsync(CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultParameter, CrosstenantAccessPolicyConfigurationdefaultResettosystemdefaultResponse>(parameter, cancellationToken);
        }
    }
}
