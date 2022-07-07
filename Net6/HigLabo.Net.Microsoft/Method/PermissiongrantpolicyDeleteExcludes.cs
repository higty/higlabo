using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyDeleteExcludesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_PermissiongrantpolicyId_Excludes_ExcludeId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_PermissiongrantpolicyId_Excludes_ExcludeId: return $"/policies/permissionGrantPolicies/{PermissiongrantpolicyId}/excludes/{ExcludeId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PermissiongrantpolicyId { get; set; }
        public string ExcludeId { get; set; }
    }
    public partial class PermissiongrantpolicyDeleteExcludesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteExcludesResponse> PermissiongrantpolicyDeleteExcludesAsync()
        {
            var p = new PermissiongrantpolicyDeleteExcludesParameter();
            return await this.SendAsync<PermissiongrantpolicyDeleteExcludesParameter, PermissiongrantpolicyDeleteExcludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteExcludesResponse> PermissiongrantpolicyDeleteExcludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyDeleteExcludesParameter();
            return await this.SendAsync<PermissiongrantpolicyDeleteExcludesParameter, PermissiongrantpolicyDeleteExcludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteExcludesResponse> PermissiongrantpolicyDeleteExcludesAsync(PermissiongrantpolicyDeleteExcludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyDeleteExcludesParameter, PermissiongrantpolicyDeleteExcludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteExcludesResponse> PermissiongrantpolicyDeleteExcludesAsync(PermissiongrantpolicyDeleteExcludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyDeleteExcludesParameter, PermissiongrantpolicyDeleteExcludesResponse>(parameter, cancellationToken);
        }
    }
}
