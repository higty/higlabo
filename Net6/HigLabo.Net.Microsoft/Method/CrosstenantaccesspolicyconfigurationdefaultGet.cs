using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyconfigurationdefaultGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Default,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Default: return $"/policies/crossTenantAccessPolicy/default";
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
    public partial class CrosstenantaccesspolicyconfigurationdefaultGetResponse : RestApiResponse
    {
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
        public bool? IsServiceDefault { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultGetResponse> CrosstenantaccesspolicyconfigurationdefaultGetAsync()
        {
            var p = new CrosstenantaccesspolicyconfigurationdefaultGetParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultGetParameter, CrosstenantaccesspolicyconfigurationdefaultGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultGetResponse> CrosstenantaccesspolicyconfigurationdefaultGetAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyconfigurationdefaultGetParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultGetParameter, CrosstenantaccesspolicyconfigurationdefaultGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultGetResponse> CrosstenantaccesspolicyconfigurationdefaultGetAsync(CrosstenantaccesspolicyconfigurationdefaultGetParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultGetParameter, CrosstenantaccesspolicyconfigurationdefaultGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultGetResponse> CrosstenantaccesspolicyconfigurationdefaultGetAsync(CrosstenantaccesspolicyconfigurationdefaultGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultGetParameter, CrosstenantaccesspolicyconfigurationdefaultGetResponse>(parameter, cancellationToken);
        }
    }
}
