using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy: return $"/policies/crossTenantAccessPolicy";
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
    public partial class CrosstenantaccesspolicyGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyGetResponse> CrosstenantaccesspolicyGetAsync()
        {
            var p = new CrosstenantaccesspolicyGetParameter();
            return await this.SendAsync<CrosstenantaccesspolicyGetParameter, CrosstenantaccesspolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyGetResponse> CrosstenantaccesspolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyGetParameter();
            return await this.SendAsync<CrosstenantaccesspolicyGetParameter, CrosstenantaccesspolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyGetResponse> CrosstenantaccesspolicyGetAsync(CrosstenantaccesspolicyGetParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyGetParameter, CrosstenantaccesspolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyGetResponse> CrosstenantaccesspolicyGetAsync(CrosstenantaccesspolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyGetParameter, CrosstenantaccesspolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
