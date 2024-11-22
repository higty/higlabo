using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/entitlementmanagement?view=graph-rest-1.0
/// </summary>
public partial class EntitlementManagement
{
    public string? Id { get; set; }
    public Approval[]? AccessPackageAssignmentApprovals { get; set; }
    public AccessPackage[]? AccessPackages { get; set; }
    public AccessPackageAssignmentPolicy[]? AssignmentPolicies { get; set; }
    public AccessPackageAssignmentRequest[]? AssignmentRequests { get; set; }
    public AccessPackageAssignment[]? Assignments { get; set; }
    public AccessPackageCatalog[]? Catalogs { get; set; }
    public ConnectedOrganization[]? ConnectedOrganizations { get; set; }
    public AccessPackageResourceEnvironment[]? ResourceEnvironments { get; set; }
    public AccessPackageResourceRequest[]? ResourceRequests { get; set; }
    public AccessPackageResource[]? Resources { get; set; }
    public EntitlementManagementSettings? Settings { get; set; }
}
