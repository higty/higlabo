using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantaccesspolicyconfigurationpartnerDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_CrossTenantAccessPolicy_Partners_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id: return $"/policies/crossTenantAccessPolicy/partners/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class CrosstenantaccesspolicyconfigurationpartnerDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerDeleteResponse> CrosstenantaccesspolicyconfigurationpartnerDeleteAsync()
        {
            var p = new CrosstenantaccesspolicyconfigurationpartnerDeleteParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerDeleteParameter, CrosstenantaccesspolicyconfigurationpartnerDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerDeleteResponse> CrosstenantaccesspolicyconfigurationpartnerDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantaccesspolicyconfigurationpartnerDeleteParameter();
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerDeleteParameter, CrosstenantaccesspolicyconfigurationpartnerDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerDeleteResponse> CrosstenantaccesspolicyconfigurationpartnerDeleteAsync(CrosstenantaccesspolicyconfigurationpartnerDeleteParameter parameter)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerDeleteParameter, CrosstenantaccesspolicyconfigurationpartnerDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantaccesspolicyconfigurationpartnerDeleteResponse> CrosstenantaccesspolicyconfigurationpartnerDeleteAsync(CrosstenantaccesspolicyconfigurationpartnerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantaccesspolicyconfigurationpartnerDeleteParameter, CrosstenantaccesspolicyconfigurationpartnerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
