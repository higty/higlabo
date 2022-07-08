using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantPolicyDeleteExcludesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PermissiongrantpolicyId { get; set; }
            public string ExcludeId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_PermissiongrantpolicyId_Excludes_ExcludeId: return $"/policies/permissionGrantPolicies/{PermissiongrantpolicyId}/excludes/{ExcludeId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_PermissiongrantpolicyId_Excludes_ExcludeId,
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
    public partial class PermissiongrantPolicyDeleteExcludesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteExcludesResponse> PermissiongrantPolicyDeleteExcludesAsync()
        {
            var p = new PermissiongrantPolicyDeleteExcludesParameter();
            return await this.SendAsync<PermissiongrantPolicyDeleteExcludesParameter, PermissiongrantPolicyDeleteExcludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteExcludesResponse> PermissiongrantPolicyDeleteExcludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyDeleteExcludesParameter();
            return await this.SendAsync<PermissiongrantPolicyDeleteExcludesParameter, PermissiongrantPolicyDeleteExcludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteExcludesResponse> PermissiongrantPolicyDeleteExcludesAsync(PermissiongrantPolicyDeleteExcludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyDeleteExcludesParameter, PermissiongrantPolicyDeleteExcludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyDeleteExcludesResponse> PermissiongrantPolicyDeleteExcludesAsync(PermissiongrantPolicyDeleteExcludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyDeleteExcludesParameter, PermissiongrantPolicyDeleteExcludesResponse>(parameter, cancellationToken);
        }
    }
}
