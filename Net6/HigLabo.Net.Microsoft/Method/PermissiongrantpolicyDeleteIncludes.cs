using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyDeleteIncludesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_PermissiongrantpolicyId_Includes_IncludeId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_PermissiongrantpolicyId_Includes_IncludeId: return $"/policies/permissionGrantPolicies/{PermissiongrantpolicyId}/includes/{IncludeId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PermissiongrantpolicyId { get; set; }
        public string IncludeId { get; set; }
    }
    public partial class PermissiongrantpolicyDeleteIncludesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteIncludesResponse> PermissiongrantpolicyDeleteIncludesAsync()
        {
            var p = new PermissiongrantpolicyDeleteIncludesParameter();
            return await this.SendAsync<PermissiongrantpolicyDeleteIncludesParameter, PermissiongrantpolicyDeleteIncludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteIncludesResponse> PermissiongrantpolicyDeleteIncludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyDeleteIncludesParameter();
            return await this.SendAsync<PermissiongrantpolicyDeleteIncludesParameter, PermissiongrantpolicyDeleteIncludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteIncludesResponse> PermissiongrantpolicyDeleteIncludesAsync(PermissiongrantpolicyDeleteIncludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyDeleteIncludesParameter, PermissiongrantpolicyDeleteIncludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteIncludesResponse> PermissiongrantpolicyDeleteIncludesAsync(PermissiongrantpolicyDeleteIncludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyDeleteIncludesParameter, PermissiongrantpolicyDeleteIncludesResponse>(parameter, cancellationToken);
        }
    }
}
