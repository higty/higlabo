using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies: return $"/policies/homeRealmDiscoveryPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesAsync()
        {
            var p = new HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesAsync(HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-post-homerealmdiscoverypolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse> HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesAsync(HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesParameter, HomerealmdiscoverypolicyPostHomerealmdiscoverypoliciesResponse>(parameter, cancellationToken);
        }
    }
}
