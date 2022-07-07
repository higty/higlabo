using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingpolicyPostClaimsmappingpoliciesParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ClaimsmappingpolicyPostClaimsmappingpoliciesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyPostClaimsmappingpoliciesResponse> ClaimsmappingpolicyPostClaimsmappingpoliciesAsync()
        {
            var p = new ClaimsmappingpolicyPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ClaimsmappingpolicyPostClaimsmappingpoliciesParameter, ClaimsmappingpolicyPostClaimsmappingpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyPostClaimsmappingpoliciesResponse> ClaimsmappingpolicyPostClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingpolicyPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ClaimsmappingpolicyPostClaimsmappingpoliciesParameter, ClaimsmappingpolicyPostClaimsmappingpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyPostClaimsmappingpoliciesResponse> ClaimsmappingpolicyPostClaimsmappingpoliciesAsync(ClaimsmappingpolicyPostClaimsmappingpoliciesParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingpolicyPostClaimsmappingpoliciesParameter, ClaimsmappingpolicyPostClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyPostClaimsmappingpoliciesResponse> ClaimsmappingpolicyPostClaimsmappingpoliciesAsync(ClaimsmappingpolicyPostClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingpolicyPostClaimsmappingpoliciesParameter, ClaimsmappingpolicyPostClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
