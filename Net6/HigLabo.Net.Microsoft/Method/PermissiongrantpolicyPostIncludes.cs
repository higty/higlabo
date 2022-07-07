using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyPostIncludesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id_Includes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id_Includes: return $"/policies/permissionGrantPolicies/{Id}/includes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class PermissiongrantpolicyPostIncludesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostIncludesResponse> PermissiongrantpolicyPostIncludesAsync()
        {
            var p = new PermissiongrantpolicyPostIncludesParameter();
            return await this.SendAsync<PermissiongrantpolicyPostIncludesParameter, PermissiongrantpolicyPostIncludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostIncludesResponse> PermissiongrantpolicyPostIncludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyPostIncludesParameter();
            return await this.SendAsync<PermissiongrantpolicyPostIncludesParameter, PermissiongrantpolicyPostIncludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostIncludesResponse> PermissiongrantpolicyPostIncludesAsync(PermissiongrantpolicyPostIncludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyPostIncludesParameter, PermissiongrantpolicyPostIncludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyPostIncludesResponse> PermissiongrantpolicyPostIncludesAsync(PermissiongrantpolicyPostIncludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyPostIncludesParameter, PermissiongrantpolicyPostIncludesResponse>(parameter, cancellationToken);
        }
    }
}
