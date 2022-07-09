using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoveryPolicyListParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Id,
            Definition,
            Description,
            DisplayName,
            IsOrganizationDefault,
            AppliesTo,
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
    public partial class HomerealmdiscoveryPolicyListResponse : RestApiResponse
    {
        public HomeRealmDiscoveryPolicy[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListResponse> HomerealmdiscoveryPolicyListAsync()
        {
            var p = new HomerealmdiscoveryPolicyListParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyListParameter, HomerealmdiscoveryPolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListResponse> HomerealmdiscoveryPolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoveryPolicyListParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyListParameter, HomerealmdiscoveryPolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListResponse> HomerealmdiscoveryPolicyListAsync(HomerealmdiscoveryPolicyListParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyListParameter, HomerealmdiscoveryPolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListResponse> HomerealmdiscoveryPolicyListAsync(HomerealmdiscoveryPolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyListParameter, HomerealmdiscoveryPolicyListResponse>(parameter, cancellationToken);
        }
    }
}
