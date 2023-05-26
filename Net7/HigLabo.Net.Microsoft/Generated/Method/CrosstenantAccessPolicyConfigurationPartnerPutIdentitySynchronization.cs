using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-put-identitysynchronization?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? DisplayName { get; set; }
        public CrossTenantUserSyncInbound? UserSyncInbound { get; set; }
    }
    public partial class CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-put-identitysynchronization?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-put-identitysynchronization?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse> CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationAsync()
        {
            var p = new CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter, CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-put-identitysynchronization?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse> CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter, CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-put-identitysynchronization?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse> CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationAsync(CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter, CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-put-identitysynchronization?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse> CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationAsync(CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationParameter, CrosstenantAccessPolicyConfigurationPartnerPutIdentitySynchronizationResponse>(parameter, cancellationToken);
        }
    }
}
