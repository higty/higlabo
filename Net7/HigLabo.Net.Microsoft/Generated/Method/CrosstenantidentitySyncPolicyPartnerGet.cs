using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-get?view=graph-rest-1.0
    /// </summary>
    public partial class CrosstenantidentitySyncPolicyPartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id_IdentitySynchronization: return $"/policies/crossTenantAccessPolicy/partners/{Id}/identitySynchronization";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners_Id_IdentitySynchronization,
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
    public partial class CrosstenantidentitySyncPolicyPartnerGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? TenantId { get; set; }
        public CrossTenantUserSyncInbound? UserSyncInbound { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantidentitySyncPolicyPartnerGetResponse> CrosstenantidentitySyncPolicyPartnerGetAsync()
        {
            var p = new CrosstenantidentitySyncPolicyPartnerGetParameter();
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerGetParameter, CrosstenantidentitySyncPolicyPartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantidentitySyncPolicyPartnerGetResponse> CrosstenantidentitySyncPolicyPartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantidentitySyncPolicyPartnerGetParameter();
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerGetParameter, CrosstenantidentitySyncPolicyPartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantidentitySyncPolicyPartnerGetResponse> CrosstenantidentitySyncPolicyPartnerGetAsync(CrosstenantidentitySyncPolicyPartnerGetParameter parameter)
        {
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerGetParameter, CrosstenantidentitySyncPolicyPartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CrosstenantidentitySyncPolicyPartnerGetResponse> CrosstenantidentitySyncPolicyPartnerGetAsync(CrosstenantidentitySyncPolicyPartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerGetParameter, CrosstenantidentitySyncPolicyPartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
