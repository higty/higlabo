using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoverypolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id: return $"/policies/homeRealmDiscoveryPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class HomerealmdiscoverypolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyDeleteResponse> HomerealmdiscoverypolicyDeleteAsync()
        {
            var p = new HomerealmdiscoverypolicyDeleteParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyDeleteParameter, HomerealmdiscoverypolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyDeleteResponse> HomerealmdiscoverypolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoverypolicyDeleteParameter();
            return await this.SendAsync<HomerealmdiscoverypolicyDeleteParameter, HomerealmdiscoverypolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyDeleteResponse> HomerealmdiscoverypolicyDeleteAsync(HomerealmdiscoverypolicyDeleteParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyDeleteParameter, HomerealmdiscoverypolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoverypolicyDeleteResponse> HomerealmdiscoverypolicyDeleteAsync(HomerealmdiscoverypolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoverypolicyDeleteParameter, HomerealmdiscoverypolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
