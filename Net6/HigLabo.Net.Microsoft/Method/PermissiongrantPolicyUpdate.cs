using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantPolicyUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class PermissiongrantPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyUpdateResponse> PermissiongrantPolicyUpdateAsync()
        {
            var p = new PermissiongrantPolicyUpdateParameter();
            return await this.SendAsync<PermissiongrantPolicyUpdateParameter, PermissiongrantPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyUpdateResponse> PermissiongrantPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyUpdateParameter();
            return await this.SendAsync<PermissiongrantPolicyUpdateParameter, PermissiongrantPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyUpdateResponse> PermissiongrantPolicyUpdateAsync(PermissiongrantPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyUpdateParameter, PermissiongrantPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyUpdateResponse> PermissiongrantPolicyUpdateAsync(PermissiongrantPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyUpdateParameter, PermissiongrantPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
