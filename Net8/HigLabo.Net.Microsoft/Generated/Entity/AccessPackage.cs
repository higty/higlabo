using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackage?view=graph-rest-1.0
/// </summary>
public partial class AccessPackage
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
