using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies: return $"/policies/homeRealmDiscoveryPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies,
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
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    public partial class HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesAsync()
        {
            var p = new HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesAsync(HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesAsync(HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoveryPolicyPostHomerealmdiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
