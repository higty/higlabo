using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class HomerealmdiscoveryPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class HomerealmdiscoveryPolicyGetResponse : RestApiResponse
    {
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyGetResponse> HomerealmdiscoveryPolicyGetAsync()
        {
            var p = new HomerealmdiscoveryPolicyGetParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyGetParameter, HomerealmdiscoveryPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyGetResponse> HomerealmdiscoveryPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoveryPolicyGetParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyGetParameter, HomerealmdiscoveryPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyGetResponse> HomerealmdiscoveryPolicyGetAsync(HomerealmdiscoveryPolicyGetParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyGetParameter, HomerealmdiscoveryPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyGetResponse> HomerealmdiscoveryPolicyGetAsync(HomerealmdiscoveryPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyGetParameter, HomerealmdiscoveryPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
