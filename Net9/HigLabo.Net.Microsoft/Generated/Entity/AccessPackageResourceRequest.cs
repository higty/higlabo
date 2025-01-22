using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresourcerequest?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageResourceRequest
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public string? RequestType { get; set; }
    public string? State { get; set; }
    public AccessPackageCatalog? Catalog { get; set; }
    public AccessPackageResource? Resource { get; set; }
}
