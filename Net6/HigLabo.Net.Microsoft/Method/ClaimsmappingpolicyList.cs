using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class ClaimsmappingPolicyListParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Definition,
            DisplayName,
            Id,
            IsOrganizationDefault,
            AppliesTo,
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
    public partial class ClaimsmappingPolicyListResponse : RestApiResponse
    {
        public ClaimsMappingPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyListResponse> ClaimsmappingPolicyListAsync()
        {
            var p = new ClaimsmappingPolicyListParameter();
            return await this.SendAsync<ClaimsmappingPolicyListParameter, ClaimsmappingPolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyListResponse> ClaimsmappingPolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingPolicyListParameter();
            return await this.SendAsync<ClaimsmappingPolicyListParameter, ClaimsmappingPolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyListResponse> ClaimsmappingPolicyListAsync(ClaimsmappingPolicyListParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingPolicyListParameter, ClaimsmappingPolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyListResponse> ClaimsmappingPolicyListAsync(ClaimsmappingPolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingPolicyListParameter, ClaimsmappingPolicyListResponse>(parameter, cancellationToken);
        }
    }
}
