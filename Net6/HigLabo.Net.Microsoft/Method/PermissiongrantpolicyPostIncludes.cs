using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantPolicyPostIncludesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id_Includes: return $"/policies/permissionGrantPolicies/{Id}/includes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum PermissionGrantConditionSetPermissionType
        {
            Application,
            Delegated,
            DelegatedUserConsentable,
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id_Includes,
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
    public partial class PermissiongrantPolicyPostIncludesResponse : RestApiResponse
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
        public async Task<PermissiongrantPolicyPostIncludesResponse> PermissiongrantPolicyPostIncludesAsync()
        {
            var p = new PermissiongrantPolicyPostIncludesParameter();
            return await this.SendAsync<PermissiongrantPolicyPostIncludesParameter, PermissiongrantPolicyPostIncludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostIncludesResponse> PermissiongrantPolicyPostIncludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantPolicyPostIncludesParameter();
            return await this.SendAsync<PermissiongrantPolicyPostIncludesParameter, PermissiongrantPolicyPostIncludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostIncludesResponse> PermissiongrantPolicyPostIncludesAsync(PermissiongrantPolicyPostIncludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantPolicyPostIncludesParameter, PermissiongrantPolicyPostIncludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-post-includes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantPolicyPostIncludesResponse> PermissiongrantPolicyPostIncludesAsync(PermissiongrantPolicyPostIncludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantPolicyPostIncludesParameter, PermissiongrantPolicyPostIncludesResponse>(parameter, cancellationToken);
        }
    }
}
