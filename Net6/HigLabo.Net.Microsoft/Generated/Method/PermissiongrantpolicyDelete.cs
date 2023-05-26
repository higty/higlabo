using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class PermissiongrantPolicyDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id: return $"/policies/permissionGrantPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class PermissiongrantPolicyDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteResponse> PermissiongrantPolicyDeleteAsync()
        {
            var p = new PermissiongrantPolicyDeleteParameter();
            return await this.SendAsync<PermissiongrantPolicyDeleteParameter, PermissiongrantPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteResponse> PermissiongrantPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyDeleteParameter();
            return await this.SendAsync<PermissiongrantPolicyDeleteParameter, PermissiongrantPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteResponse> PermissiongrantPolicyDeleteAsync(PermissiongrantPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyDeleteParameter, PermissiongrantPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteResponse> PermissiongrantPolicyDeleteAsync(PermissiongrantPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyDeleteParameter, PermissiongrantPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
