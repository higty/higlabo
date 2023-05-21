using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantAccessPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy: return $"/policies/crossTenantAccessPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy,
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
    public partial class CrosstenantAccessPolicyGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public String[]? AllowedCloudEndpoints { get; set; }
        public CrossTenantAccessPolicyConfigurationDefault? Default { get; set; }
        public CrossTenantAccessPolicyConfigurationPartner[]? Partners { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyGetResponse> CrosstenantAccessPolicyGetAsync()
        {
            var p = new CrosstenantAccessPolicyGetParameter();
            return await this.SendAsync<CrosstenantAccessPolicyGetParameter, CrosstenantAccessPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyGetResponse> CrosstenantAccessPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyGetParameter();
            return await this.SendAsync<CrosstenantAccessPolicyGetParameter, CrosstenantAccessPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyGetResponse> CrosstenantAccessPolicyGetAsync(CrosstenantAccessPolicyGetParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyGetParameter, CrosstenantAccessPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyGetResponse> CrosstenantAccessPolicyGetAsync(CrosstenantAccessPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyGetParameter, CrosstenantAccessPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
