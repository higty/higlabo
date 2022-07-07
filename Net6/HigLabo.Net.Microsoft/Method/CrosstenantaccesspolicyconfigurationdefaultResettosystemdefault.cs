using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Default_ResetToSystemDefault,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Default_ResetToSystemDefault: return $"/policies/crossTenantAccessPolicy/default/resetToSystemDefault";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse> CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultAsync()
        {
            var p = new CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter, CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse> CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter, CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse> CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultAsync(CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter, CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-resettosystemdefault?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse> CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultAsync(CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultParameter, CrosstenantaccesspolicyconfigurationdefaultResettosystemdefaultResponse>(parameter, cancellationToken);
        }
    }
}
