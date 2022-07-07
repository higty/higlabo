using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id: return $"/policies/permissionGrantPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class PermissiongrantpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteResponse> PermissiongrantpolicyDeleteAsync()
        {
            var p = new PermissiongrantpolicyDeleteParameter();
            return await this.SendAsync<PermissiongrantpolicyDeleteParameter, PermissiongrantpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteResponse> PermissiongrantpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyDeleteParameter();
            return await this.SendAsync<PermissiongrantpolicyDeleteParameter, PermissiongrantpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteResponse> PermissiongrantpolicyDeleteAsync(PermissiongrantpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyDeleteParameter, PermissiongrantpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyDeleteResponse> PermissiongrantpolicyDeleteAsync(PermissiongrantpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyDeleteParameter, PermissiongrantpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
