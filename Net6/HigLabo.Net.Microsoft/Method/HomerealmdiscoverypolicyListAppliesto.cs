using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class HomerealmdiscoveryPolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id_AppliesTo: return $"/policies/homeRealmDiscoveryPolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Policies_HomeRealmDiscoveryPolicies_Id_AppliesTo,
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
    public partial class HomerealmdiscoveryPolicyListAppliestoResponse : RestApiResponse
    {
        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListAppliestoResponse> HomerealmdiscoveryPolicyListAppliestoAsync()
        {
            var p = new HomerealmdiscoveryPolicyListAppliestoParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyListAppliestoParameter, HomerealmdiscoveryPolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListAppliestoResponse> HomerealmdiscoveryPolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new HomerealmdiscoveryPolicyListAppliestoParameter();
            return await this.SendAsync<HomerealmdiscoveryPolicyListAppliestoParameter, HomerealmdiscoveryPolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListAppliestoResponse> HomerealmdiscoveryPolicyListAppliestoAsync(HomerealmdiscoveryPolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyListAppliestoParameter, HomerealmdiscoveryPolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<HomerealmdiscoveryPolicyListAppliestoResponse> HomerealmdiscoveryPolicyListAppliestoAsync(HomerealmdiscoveryPolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<HomerealmdiscoveryPolicyListAppliestoParameter, HomerealmdiscoveryPolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
