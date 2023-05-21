using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-update?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantAccessPolicyConfigurationdefaultUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Default: return $"/policies/crossTenantAccessPolicy/default";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Default,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
    }
    public partial class CrosstenantAccessPolicyConfigurationdefaultUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultUpdateResponse> CrosstenantAccessPolicyConfigurationdefaultUpdateAsync()
        {
            var p = new CrosstenantAccessPolicyConfigurationdefaultUpdateParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultUpdateParameter, CrosstenantAccessPolicyConfigurationdefaultUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultUpdateResponse> CrosstenantAccessPolicyConfigurationdefaultUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyConfigurationdefaultUpdateParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultUpdateParameter, CrosstenantAccessPolicyConfigurationdefaultUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultUpdateResponse> CrosstenantAccessPolicyConfigurationdefaultUpdateAsync(CrosstenantAccessPolicyConfigurationdefaultUpdateParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultUpdateParameter, CrosstenantAccessPolicyConfigurationdefaultUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationdefaultUpdateResponse> CrosstenantAccessPolicyConfigurationdefaultUpdateAsync(CrosstenantAccessPolicyConfigurationdefaultUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultUpdateParameter, CrosstenantAccessPolicyConfigurationdefaultUpdateResponse>(parameter, cancellationToken);
        }
    }
}
