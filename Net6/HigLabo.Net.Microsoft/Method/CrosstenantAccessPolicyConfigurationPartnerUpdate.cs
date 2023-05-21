using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-update?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantAccessPolicyConfigurationPartnerUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id: return $"/policies/crossTenantAccessPolicy/partners/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners_Id,
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
        public InboundOutboundPolicyConfiguration? AutomaticUserConsentSettings { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
    }
    public partial class CrosstenantAccessPolicyConfigurationPartnerUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerUpdateResponse> CrosstenantAccessPolicyConfigurationPartnerUpdateAsync()
        {
            var p = new CrosstenantAccessPolicyConfigurationPartnerUpdateParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerUpdateParameter, CrosstenantAccessPolicyConfigurationPartnerUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerUpdateResponse> CrosstenantAccessPolicyConfigurationPartnerUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyConfigurationPartnerUpdateParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerUpdateParameter, CrosstenantAccessPolicyConfigurationPartnerUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerUpdateResponse> CrosstenantAccessPolicyConfigurationPartnerUpdateAsync(CrosstenantAccessPolicyConfigurationPartnerUpdateParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerUpdateParameter, CrosstenantAccessPolicyConfigurationPartnerUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerUpdateResponse> CrosstenantAccessPolicyConfigurationPartnerUpdateAsync(CrosstenantAccessPolicyConfigurationPartnerUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerUpdateParameter, CrosstenantAccessPolicyConfigurationPartnerUpdateResponse>(parameter, cancellationToken);
        }
    }
}
