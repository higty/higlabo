using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingpolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_ClaimsMappingPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_ClaimsMappingPolicies: return $"/policies/claimsMappingPolicies";
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
    public partial class ClaimsmappingpolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/claimsmappingpolicy?view=graph-rest-1.0
        /// </summary>
        public partial class ClaimsMappingPolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public ClaimsMappingPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListResponse> ClaimsmappingpolicyListAsync()
        {
            var p = new ClaimsmappingpolicyListParameter();
            return await this.SendAsync<ClaimsmappingpolicyListParameter, ClaimsmappingpolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListResponse> ClaimsmappingpolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingpolicyListParameter();
            return await this.SendAsync<ClaimsmappingpolicyListParameter, ClaimsmappingpolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListResponse> ClaimsmappingpolicyListAsync(ClaimsmappingpolicyListParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingpolicyListParameter, ClaimsmappingpolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyListResponse> ClaimsmappingpolicyListAsync(ClaimsmappingpolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingpolicyListParameter, ClaimsmappingpolicyListResponse>(parameter, cancellationToken);
        }
    }
}
