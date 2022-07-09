using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantAccessPolicyConfigurationPartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id: return $"/policies/crossTenantAccessPolicy/partners/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners_Id,
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
    public partial class CrosstenantAccessPolicyConfigurationPartnerGetResponse : RestApiResponse
    {
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
        public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
        public bool? IsServiceProvider { get; set; }
        public string? TenantId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerGetResponse> CrosstenantAccessPolicyConfigurationPartnerGetAsync()
        {
            var p = new CrosstenantAccessPolicyConfigurationPartnerGetParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerGetParameter, CrosstenantAccessPolicyConfigurationPartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerGetResponse> CrosstenantAccessPolicyConfigurationPartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyConfigurationPartnerGetParameter();
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerGetParameter, CrosstenantAccessPolicyConfigurationPartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerGetResponse> CrosstenantAccessPolicyConfigurationPartnerGetAsync(CrosstenantAccessPolicyConfigurationPartnerGetParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerGetParameter, CrosstenantAccessPolicyConfigurationPartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyConfigurationPartnerGetResponse> CrosstenantAccessPolicyConfigurationPartnerGetAsync(CrosstenantAccessPolicyConfigurationPartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerGetParameter, CrosstenantAccessPolicyConfigurationPartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
