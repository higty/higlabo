using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ClaimsmappingpolicyDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class ClaimsmappingpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyDeleteResponse> ClaimsmappingpolicyDeleteAsync()
        {
            var p = new ClaimsmappingpolicyDeleteParameter();
            return await this.SendAsync<ClaimsmappingpolicyDeleteParameter, ClaimsmappingpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyDeleteResponse> ClaimsmappingpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingpolicyDeleteParameter();
            return await this.SendAsync<ClaimsmappingpolicyDeleteParameter, ClaimsmappingpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyDeleteResponse> ClaimsmappingpolicyDeleteAsync(ClaimsmappingpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingpolicyDeleteParameter, ClaimsmappingpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/claimsmappingpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingpolicyDeleteResponse> ClaimsmappingpolicyDeleteAsync(ClaimsmappingpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingpolicyDeleteParameter, ClaimsmappingpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
