using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyPostPartnersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners: return $"/policies/crossTenantAccessPolicy/partners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
        public string? TenantId { get; set; }
    }
    public partial class CrosstenantaccesspolicyPostPartnersResponse : RestApiResponse
    {
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
        public bool? IsServiceProvider { get; set; }
        public string? TenantId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyPostPartnersResponse> CrosstenantaccesspolicyPostPartnersAsync()
        {
            var p = new CrosstenantaccesspolicyPostPartnersParameter();
            return await this.SendAsync<CrosstenantaccesspolicyPostPartnersParameter, CrosstenantaccesspolicyPostPartnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyPostPartnersResponse> CrosstenantaccesspolicyPostPartnersAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyPostPartnersParameter();
            return await this.SendAsync<CrosstenantaccesspolicyPostPartnersParameter, CrosstenantaccesspolicyPostPartnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyPostPartnersResponse> CrosstenantaccesspolicyPostPartnersAsync(CrosstenantaccesspolicyPostPartnersParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyPostPartnersParameter, CrosstenantaccesspolicyPostPartnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-post-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyPostPartnersResponse> CrosstenantaccesspolicyPostPartnersAsync(CrosstenantaccesspolicyPostPartnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyPostPartnersParameter, CrosstenantaccesspolicyPostPartnersResponse>(parameter, cancellationToken);
        }
    }
}
