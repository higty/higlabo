using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-update?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantidentitySyncPolicyPartnerUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id_IdentitySynchronization: return $"/policies/crossTenantAccessPolicy/partners/{Id}/identitySynchronization";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners_Id_IdentitySynchronization,
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
        public string? DisplayName { get; set; }
        public CrossTenantUserSyncInbound? UserSyncInbound { get; set; }
    }
    public partial class CrosstenantidentitySyncPolicyPartnerUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantidentitySyncPolicyPartnerUpdateResponse> CrosstenantidentitySyncPolicyPartnerUpdateAsync()
        {
            var p = new CrosstenantidentitySyncPolicyPartnerUpdateParameter();
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerUpdateParameter, CrosstenantidentitySyncPolicyPartnerUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantidentitySyncPolicyPartnerUpdateResponse> CrosstenantidentitySyncPolicyPartnerUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantidentitySyncPolicyPartnerUpdateParameter();
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerUpdateParameter, CrosstenantidentitySyncPolicyPartnerUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantidentitySyncPolicyPartnerUpdateResponse> CrosstenantidentitySyncPolicyPartnerUpdateAsync(CrosstenantidentitySyncPolicyPartnerUpdateParameter parameter)
        {
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerUpdateParameter, CrosstenantidentitySyncPolicyPartnerUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantidentitySyncPolicyPartnerUpdateResponse> CrosstenantidentitySyncPolicyPartnerUpdateAsync(CrosstenantidentitySyncPolicyPartnerUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerUpdateParameter, CrosstenantidentitySyncPolicyPartnerUpdateResponse>(parameter, cancellationToken);
        }
    }
}
