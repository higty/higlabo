using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantAccessPolicyPostPartnersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners: return $"/policies/crossTenantAccessPolicy/partners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners,
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
        public InboundOutboundPolicyConfiguration? AutomaticUserConsentSettings { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
        public bool? IsServiceProvider { get; set; }
        public string? TenantId { get; set; }
        public CrossTenantIdentitySyncPolicyPartner? IdentitySynchronization { get; set; }
    }
    public partial class CrosstenantAccessPolicyPostPartnersResponse : RestApiResponse
    {
        public InboundOutboundPolicyConfiguration? AutomaticUserConsentSettings { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
        public bool? IsServiceProvider { get; set; }
        public string? TenantId { get; set; }
        public CrossTenantIdentitySyncPolicyPartner? IdentitySynchronization { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantAccessPolicyPostPartnersResponse> CrosstenantAccessPolicyPostPartnersAsync()
        {
            var p = new CrosstenantAccessPolicyPostPartnersParameter();
            return await this.SendAsync<CrosstenantAccessPolicyPostPartnersParameter, CrosstenantAccessPolicyPostPartnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantAccessPolicyPostPartnersResponse> CrosstenantAccessPolicyPostPartnersAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyPostPartnersParameter();
            return await this.SendAsync<CrosstenantAccessPolicyPostPartnersParameter, CrosstenantAccessPolicyPostPartnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantAccessPolicyPostPartnersResponse> CrosstenantAccessPolicyPostPartnersAsync(CrosstenantAccessPolicyPostPartnersParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyPostPartnersParameter, CrosstenantAccessPolicyPostPartnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantAccessPolicyPostPartnersResponse> CrosstenantAccessPolicyPostPartnersAsync(CrosstenantAccessPolicyPostPartnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyPostPartnersParameter, CrosstenantAccessPolicyPostPartnersResponse>(parameter, cancellationToken);
        }
    }
}
