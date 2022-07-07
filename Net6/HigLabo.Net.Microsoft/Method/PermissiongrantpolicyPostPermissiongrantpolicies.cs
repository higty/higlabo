using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyPostPermissiongrantpoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies: return $"/policies/permissionGrantPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class PermissiongrantpolicyPostPermissiongrantpoliciesResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public PermissionGrantConditionSet[]? Includes { get; set; }
        public PermissionGrantConditionSet[]? Excludes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostPermissiongrantpoliciesResponse> PermissiongrantpolicyPostPermissiongrantpoliciesAsync()
        {
            var p = new PermissiongrantpolicyPostPermissiongrantpoliciesParameter();
            return await this.SendAsync<PermissiongrantpolicyPostPermissiongrantpoliciesParameter, PermissiongrantpolicyPostPermissiongrantpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostPermissiongrantpoliciesResponse> PermissiongrantpolicyPostPermissiongrantpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyPostPermissiongrantpoliciesParameter();
            return await this.SendAsync<PermissiongrantpolicyPostPermissiongrantpoliciesParameter, PermissiongrantpolicyPostPermissiongrantpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostPermissiongrantpoliciesResponse> PermissiongrantpolicyPostPermissiongrantpoliciesAsync(PermissiongrantpolicyPostPermissiongrantpoliciesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyPostPermissiongrantpoliciesParameter, PermissiongrantpolicyPostPermissiongrantpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostPermissiongrantpoliciesResponse> PermissiongrantpolicyPostPermissiongrantpoliciesAsync(PermissiongrantpolicyPostPermissiongrantpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyPostPermissiongrantpoliciesParameter, PermissiongrantpolicyPostPermissiongrantpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
