using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ClaimsmappingPolicyPostClaimsmappingpoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_ClaimsMappingPolicies: return $"/policies/claimsMappingPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_ClaimsMappingPolicies,
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
        public String[]? Definition { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    public partial class ClaimsmappingPolicyPostClaimsmappingpoliciesResponse : RestApiResponse
    {
        public String[]? Definition { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ClaimsmappingPolicyPostClaimsmappingpoliciesResponse> ClaimsmappingPolicyPostClaimsmappingpoliciesAsync()
        {
            var p = new ClaimsmappingPolicyPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ClaimsmappingPolicyPostClaimsmappingpoliciesParameter, ClaimsmappingPolicyPostClaimsmappingpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ClaimsmappingPolicyPostClaimsmappingpoliciesResponse> ClaimsmappingPolicyPostClaimsmappingpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingPolicyPostClaimsmappingpoliciesParameter();
            return await this.SendAsync<ClaimsmappingPolicyPostClaimsmappingpoliciesParameter, ClaimsmappingPolicyPostClaimsmappingpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ClaimsmappingPolicyPostClaimsmappingpoliciesResponse> ClaimsmappingPolicyPostClaimsmappingpoliciesAsync(ClaimsmappingPolicyPostClaimsmappingpoliciesParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingPolicyPostClaimsmappingpoliciesParameter, ClaimsmappingPolicyPostClaimsmappingpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-post-claimsmappingpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ClaimsmappingPolicyPostClaimsmappingpoliciesResponse> ClaimsmappingPolicyPostClaimsmappingpoliciesAsync(ClaimsmappingPolicyPostClaimsmappingpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingPolicyPostClaimsmappingpoliciesParameter, ClaimsmappingPolicyPostClaimsmappingpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
