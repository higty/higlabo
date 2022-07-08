using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CrosstenantAccessPolicyUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
    }
    public partial class CrosstenantAccessPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyUpdateResponse> CrosstenantAccessPolicyUpdateAsync()
        {
            var p = new CrosstenantAccessPolicyUpdateParameter();
            return await this.SendAsync<CrosstenantAccessPolicyUpdateParameter, CrosstenantAccessPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyUpdateResponse> CrosstenantAccessPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new CrosstenantAccessPolicyUpdateParameter();
            return await this.SendAsync<CrosstenantAccessPolicyUpdateParameter, CrosstenantAccessPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyUpdateResponse> CrosstenantAccessPolicyUpdateAsync(CrosstenantAccessPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<CrosstenantAccessPolicyUpdateParameter, CrosstenantAccessPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<CrosstenantAccessPolicyUpdateResponse> CrosstenantAccessPolicyUpdateAsync(CrosstenantAccessPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CrosstenantAccessPolicyUpdateParameter, CrosstenantAccessPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
