using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementManagementPostAccesspackagesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages,
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
        public bool? IsHidden { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AccessPackageAssignmentPolicy[]? AssignmentPolicies { get; set; }
        public AccessPackageCatalog? Catalog { get; set; }
    }
    public partial class EntitlementManagementPostAccesspackagesResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AccessPackageAssignmentPolicy[]? AssignmentPolicies { get; set; }
        public AccessPackageCatalog? Catalog { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAccesspackagesResponse> EntitlementManagementPostAccesspackagesAsync()
        {
            var p = new EntitlementManagementPostAccesspackagesParameter();
            return await this.SendAsync<EntitlementManagementPostAccesspackagesParameter, EntitlementManagementPostAccesspackagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAccesspackagesResponse> EntitlementManagementPostAccesspackagesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementPostAccesspackagesParameter();
            return await this.SendAsync<EntitlementManagementPostAccesspackagesParameter, EntitlementManagementPostAccesspackagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAccesspackagesResponse> EntitlementManagementPostAccesspackagesAsync(EntitlementManagementPostAccesspackagesParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementPostAccesspackagesParameter, EntitlementManagementPostAccesspackagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostAccesspackagesResponse> EntitlementManagementPostAccesspackagesAsync(EntitlementManagementPostAccesspackagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementPostAccesspackagesParameter, EntitlementManagementPostAccesspackagesResponse>(parameter, cancellationToken);
        }
    }
}
