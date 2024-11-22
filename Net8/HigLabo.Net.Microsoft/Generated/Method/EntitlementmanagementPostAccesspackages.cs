using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
/// </summary>
public partial class EntitlementManagementPostAccessPackagesParameter : IRestApiParameter
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
    public AccessPackage[]? AccessPackagesIncompatibleWith { get; set; }
    public AccessPackageAssignmentPolicy[]? AssignmentPolicies { get; set; }
    public AccessPackageCatalog? Catalog { get; set; }
    public AccessPackage[]? IncompatibleAccessPackages { get; set; }
    public Group[]? IncompatibleGroups { get; set; }
}
public partial class EntitlementManagementPostAccessPackagesResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsHidden { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public AccessPackage[]? AccessPackagesIncompatibleWith { get; set; }
    public AccessPackageAssignmentPolicy[]? AssignmentPolicies { get; set; }
    public AccessPackageCatalog? Catalog { get; set; }
    public AccessPackage[]? IncompatibleAccessPackages { get; set; }
    public Group[]? IncompatibleGroups { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementPostAccessPackagesResponse> EntitlementManagementPostAccessPackagesAsync()
    {
        var p = new EntitlementManagementPostAccessPackagesParameter();
        return await this.SendAsync<EntitlementManagementPostAccessPackagesParameter, EntitlementManagementPostAccessPackagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementPostAccessPackagesResponse> EntitlementManagementPostAccessPackagesAsync(CancellationToken cancellationToken)
    {
        var p = new EntitlementManagementPostAccessPackagesParameter();
        return await this.SendAsync<EntitlementManagementPostAccessPackagesParameter, EntitlementManagementPostAccessPackagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementPostAccessPackagesResponse> EntitlementManagementPostAccessPackagesAsync(EntitlementManagementPostAccessPackagesParameter parameter)
    {
        return await this.SendAsync<EntitlementManagementPostAccessPackagesParameter, EntitlementManagementPostAccessPackagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-post-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementPostAccessPackagesResponse> EntitlementManagementPostAccessPackagesAsync(EntitlementManagementPostAccessPackagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EntitlementManagementPostAccessPackagesParameter, EntitlementManagementPostAccessPackagesResponse>(parameter, cancellationToken);
    }
}
