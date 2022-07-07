using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyPostExcludesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id_Excludes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id_Excludes: return $"/policies/permissionGrantPolicies/{Id}/excludes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class PermissiongrantpolicyPostExcludesResponse : RestApiResponse
    {
        public enum PermissionGrantConditionSetPermissionType
        {
            Application,
            Delegated,
            DelegatedUserConsentable,
        }

        public string? Id { get; set; }
        public string? PermissionClassification { get; set; }
        public PermissionGrantConditionSetPermissionType PermissionType { get; set; }
        public string? ResourceApplication { get; set; }
        public String[]? Permissions { get; set; }
        public String[]? ClientApplicationIds { get; set; }
        public String[]? ClientApplicationTenantIds { get; set; }
        public String[]? ClientApplicationPublisherIds { get; set; }
        public bool? ClientApplicationsFromVerifiedPublisherOnly { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostExcludesResponse> PermissiongrantpolicyPostExcludesAsync()
        {
            var p = new PermissiongrantpolicyPostExcludesParameter();
            return await this.SendAsync<PermissiongrantpolicyPostExcludesParameter, PermissiongrantpolicyPostExcludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostExcludesResponse> PermissiongrantpolicyPostExcludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyPostExcludesParameter();
            return await this.SendAsync<PermissiongrantpolicyPostExcludesParameter, PermissiongrantpolicyPostExcludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostExcludesResponse> PermissiongrantpolicyPostExcludesAsync(PermissiongrantpolicyPostExcludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyPostExcludesParameter, PermissiongrantpolicyPostExcludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostExcludesResponse> PermissiongrantpolicyPostExcludesAsync(PermissiongrantpolicyPostExcludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyPostExcludesParameter, PermissiongrantpolicyPostExcludesResponse>(parameter, cancellationToken);
        }
    }
}
