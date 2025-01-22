using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresource?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageResource
{
    public AccessPackageResourceAttribute[]? Attributes { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public string? OriginId { get; set; }
    public string? OriginSystem { get; set; }
    public AccessPackageResourceEnvironment? Environment { get; set; }
    public AccessPackageResourceRole[]? Roles { get; set; }
    public AccessPackageResourceScope[]? Scopes { get; set; }
}
