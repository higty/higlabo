using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_ClaimsMappingPolicies_Id: return $"/policies/claimsMappingPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_ClaimsMappingPolicies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
    }
    public partial class ClaimsmappingPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyUpdateResponse> ClaimsmappingPolicyUpdateAsync()
        {
            var p = new ClaimsmappingPolicyUpdateParameter();
            return await this.SendAsync<ClaimsmappingPolicyUpdateParameter, ClaimsmappingPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyUpdateResponse> ClaimsmappingPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingPolicyUpdateParameter();
            return await this.SendAsync<ClaimsmappingPolicyUpdateParameter, ClaimsmappingPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyUpdateResponse> ClaimsmappingPolicyUpdateAsync(ClaimsmappingPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingPolicyUpdateParameter, ClaimsmappingPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyUpdateResponse> ClaimsmappingPolicyUpdateAsync(ClaimsmappingPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingPolicyUpdateParameter, ClaimsmappingPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
