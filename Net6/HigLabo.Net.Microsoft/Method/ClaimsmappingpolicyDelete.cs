using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingPolicyDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ClaimsmappingPolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyDeleteResponse> ClaimsmappingPolicyDeleteAsync()
        {
            var p = new ClaimsmappingPolicyDeleteParameter();
            return await this.SendAsync<ClaimsmappingPolicyDeleteParameter, ClaimsmappingPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyDeleteResponse> ClaimsmappingPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingPolicyDeleteParameter();
            return await this.SendAsync<ClaimsmappingPolicyDeleteParameter, ClaimsmappingPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyDeleteResponse> ClaimsmappingPolicyDeleteAsync(ClaimsmappingPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingPolicyDeleteParameter, ClaimsmappingPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyDeleteResponse> ClaimsmappingPolicyDeleteAsync(ClaimsmappingPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingPolicyDeleteParameter, ClaimsmappingPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
