using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyconfigurationpartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id: return $"/policies/crossTenantAccessPolicy/partners/{Id}";
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
        public string Id { get; set; }
    }
    public partial class CrosstenantaccesspolicyconfigurationpartnerGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerGetResponse> CrosstenantaccesspolicyconfigurationpartnerGetAsync()
        {
            var p = new CrosstenantaccesspolicyconfigurationpartnerGetParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerGetParameter, CrosstenantaccesspolicyconfigurationpartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerGetResponse> CrosstenantaccesspolicyconfigurationpartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyconfigurationpartnerGetParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerGetParameter, CrosstenantaccesspolicyconfigurationpartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerGetResponse> CrosstenantaccesspolicyconfigurationpartnerGetAsync(CrosstenantaccesspolicyconfigurationpartnerGetParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerGetParameter, CrosstenantaccesspolicyconfigurationpartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerGetResponse> CrosstenantaccesspolicyconfigurationpartnerGetAsync(CrosstenantaccesspolicyconfigurationpartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerGetParameter, CrosstenantaccesspolicyconfigurationpartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
