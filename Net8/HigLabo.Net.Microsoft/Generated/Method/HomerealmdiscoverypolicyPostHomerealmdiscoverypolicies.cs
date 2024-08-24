using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter : IRestApiParameter
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
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    public partial class HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse : RestApiResponse
    {
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse> HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesAsync()
        {
            var p = new HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter();
            return await this.SendAsync<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter, HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse> HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter();
            return await this.SendAsync<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter, HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse> HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesAsync(HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter, HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse> HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesAsync(HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesParameter, HomeRealmDiscoveryPolicyPostHomeRealmDiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
