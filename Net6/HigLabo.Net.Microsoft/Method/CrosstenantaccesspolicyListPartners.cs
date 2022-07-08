using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantAccessPolicyListPartnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners: return $"/policies/crossTenantAccessPolicy/partners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            B2bCollaborationInbound,
            B2bCollaborationOutbound,
            B2bDirectConnectInbound,
            B2bDirectConnectOutbound,
            InboundTrust,
            IsServiceProvider,
            TenantId,
        }
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners,
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
    public partial class CrosstenantAccessPolicyListPartnersResponse : RestApiResponse
    {
        public CrossTenantAccessPolicyConfigurationPartner[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync()
        {
            var p = new CrosstenantAccessPolicyListPartnersParameter();
            return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyListPartnersParameter();
            return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync(CrosstenantAccessPolicyListPartnersParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync(CrosstenantAccessPolicyListPartnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(parameter, cancellationToken);
        }
    }
}
