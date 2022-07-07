using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyListPartnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class CrosstenantaccesspolicyListPartnersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/crosstenantaccesspolicyconfigurationpartner?view=graph-rest-1.0
        /// </summary>
        public partial class CrossTenantAccessPolicyConfigurationPartner
        {
            public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
            public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
            public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
            public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
            public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
            public bool? IsServiceProvider { get; set; }
            public string? TenantId { get; set; }
        }

        public CrossTenantAccessPolicyConfigurationPartner[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyListPartnersResponse> CrosstenantaccesspolicyListPartnersAsync()
        {
            var p = new CrosstenantaccesspolicyListPartnersParameter();
            return await this.SendAsync<CrosstenantaccesspolicyListPartnersParameter, CrosstenantaccesspolicyListPartnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyListPartnersResponse> CrosstenantaccesspolicyListPartnersAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyListPartnersParameter();
            return await this.SendAsync<CrosstenantaccesspolicyListPartnersParameter, CrosstenantaccesspolicyListPartnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyListPartnersResponse> CrosstenantaccesspolicyListPartnersAsync(CrosstenantaccesspolicyListPartnersParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyListPartnersParameter, CrosstenantaccesspolicyListPartnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyListPartnersResponse> CrosstenantaccesspolicyListPartnersAsync(CrosstenantaccesspolicyListPartnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyListPartnersParameter, CrosstenantaccesspolicyListPartnersResponse>(parameter, cancellationToken);
        }
    }
}
