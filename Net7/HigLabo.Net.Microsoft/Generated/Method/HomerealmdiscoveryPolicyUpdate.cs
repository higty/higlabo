using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class HomerealmdiscoveryPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id: return $"/policies/homeRealmDiscoveryPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies_Id,
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
    public partial class HomerealmdiscoveryPolicyUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyUpdateResponse> HomerealmdiscoveryPolicyUpdateAsync()
        {
            var p = new HomerealmdiscoveryPolicyUpdateParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyUpdateParameter, HomerealmdiscoveryPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyUpdateResponse> HomerealmdiscoveryPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoveryPolicyUpdateParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyUpdateParameter, HomerealmdiscoveryPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyUpdateResponse> HomerealmdiscoveryPolicyUpdateAsync(HomerealmdiscoveryPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyUpdateParameter, HomerealmdiscoveryPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyUpdateResponse> HomerealmdiscoveryPolicyUpdateAsync(HomerealmdiscoveryPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyUpdateParameter, HomerealmdiscoveryPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
