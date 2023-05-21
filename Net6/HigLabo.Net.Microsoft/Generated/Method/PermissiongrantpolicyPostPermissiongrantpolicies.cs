using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class PermissiongrantPolicyPostPermissiongrantpoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies: return $"/policies/permissionGrantPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_PermissionGrantPolicies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public PermissionGrantConditionSet[]? Excludes { get; set; }
        public string? Id { get; set; }
        public PermissionGrantConditionSet[]? Includes { get; set; }
    }
    public partial class PermissiongrantPolicyPostPermissiongrantpoliciesResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public PermissionGrantConditionSet[]? Excludes { get; set; }
        public string? Id { get; set; }
        public PermissionGrantConditionSet[]? Includes { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostPermissiongrantpoliciesResponse> PermissiongrantPolicyPostPermissiongrantpoliciesAsync()
        {
            var p = new PermissiongrantPolicyPostPermissiongrantpoliciesParameter();
            return await this.SendAsync<PermissiongrantPolicyPostPermissiongrantpoliciesParameter, PermissiongrantPolicyPostPermissiongrantpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostPermissiongrantpoliciesResponse> PermissiongrantPolicyPostPermissiongrantpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyPostPermissiongrantpoliciesParameter();
            return await this.SendAsync<PermissiongrantPolicyPostPermissiongrantpoliciesParameter, PermissiongrantPolicyPostPermissiongrantpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostPermissiongrantpoliciesResponse> PermissiongrantPolicyPostPermissiongrantpoliciesAsync(PermissiongrantPolicyPostPermissiongrantpoliciesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyPostPermissiongrantpoliciesParameter, PermissiongrantPolicyPostPermissiongrantpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-permissiongrantpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostPermissiongrantpoliciesResponse> PermissiongrantPolicyPostPermissiongrantpoliciesAsync(PermissiongrantPolicyPostPermissiongrantpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyPostPermissiongrantpoliciesParameter, PermissiongrantPolicyPostPermissiongrantpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
