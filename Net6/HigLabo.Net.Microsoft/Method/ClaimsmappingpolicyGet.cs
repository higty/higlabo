using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class ClaimsmappingPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class ClaimsmappingPolicyGetResponse : RestApiResponse
    {
        public String[]? Definition { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyGetResponse> ClaimsmappingPolicyGetAsync()
        {
            var p = new ClaimsmappingPolicyGetParameter();
            return await this.SendAsync<ClaimsmappingPolicyGetParameter, ClaimsmappingPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyGetResponse> ClaimsmappingPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new ClaimsmappingPolicyGetParameter();
            return await this.SendAsync<ClaimsmappingPolicyGetParameter, ClaimsmappingPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyGetResponse> ClaimsmappingPolicyGetAsync(ClaimsmappingPolicyGetParameter parameter)
        {
            return await this.SendAsync<ClaimsmappingPolicyGetParameter, ClaimsmappingPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ClaimsmappingPolicyGetResponse> ClaimsmappingPolicyGetAsync(ClaimsmappingPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ClaimsmappingPolicyGetParameter, ClaimsmappingPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
