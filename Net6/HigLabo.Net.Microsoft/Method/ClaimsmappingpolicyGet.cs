using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_ClaimsMappingPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_ClaimsMappingPolicies_Id: return $"/policies/claimsMappingPolicies/{Id}";
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
    public partial class ClaimsmappingpolicyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyGetResponse> ClaimsmappingpolicyGetAsync()
        {
            var p = new ClaimsmappingpolicyGetParameter();
            return await this.SendAsync<ClaimsmappingpolicyGetParameter, ClaimsmappingpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyGetResponse> ClaimsmappingpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingpolicyGetParameter();
            return await this.SendAsync<ClaimsmappingpolicyGetParameter, ClaimsmappingpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyGetResponse> ClaimsmappingpolicyGetAsync(ClaimsmappingpolicyGetParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingpolicyGetParameter, ClaimsmappingpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyGetResponse> ClaimsmappingpolicyGetAsync(ClaimsmappingpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingpolicyGetParameter, ClaimsmappingpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
