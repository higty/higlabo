using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoveryPolicyDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class HomerealmdiscoveryPolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyDeleteResponse> HomerealmdiscoveryPolicyDeleteAsync()
        {
            var p = new HomerealmdiscoveryPolicyDeleteParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyDeleteParameter, HomerealmdiscoveryPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyDeleteResponse> HomerealmdiscoveryPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoveryPolicyDeleteParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyDeleteParameter, HomerealmdiscoveryPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyDeleteResponse> HomerealmdiscoveryPolicyDeleteAsync(HomerealmdiscoveryPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyDeleteParameter, HomerealmdiscoveryPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyDeleteResponse> HomerealmdiscoveryPolicyDeleteAsync(HomerealmdiscoveryPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyDeleteParameter, HomerealmdiscoveryPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
