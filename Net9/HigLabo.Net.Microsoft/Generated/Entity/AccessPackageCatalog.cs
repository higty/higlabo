using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackagecatalog?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageCatalog
{
    public enum AccessPackageCatalogAccessPackageCatalogType
    {
        UserManaged,
        ServiceDefault,
        ServiceManaged,
        UnknownFutureValue,
    }
    public enum AccessPackageCatalogAccessPackageCatalogState
    {
        Published,
        Unpublished,
        UnknownFutureValue,
    }

    public AccessPackageCatalogAccessPackageCatalogType CatalogType { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsExternallyVisible { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public AccessPackageCatalogAccessPackageCatalogState State { get; set; }
    public AccessPackage[]? AccessPackages { get; set; }
}
