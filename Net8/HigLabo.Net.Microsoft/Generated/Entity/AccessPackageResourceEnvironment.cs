using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresourceenvironment?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageResourceEnvironment
{
    public ConnectionInfo? ConnectionInfo { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsDefaultEnvironment { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public string? OriginId { get; set; }
    public string? OriginSystem { get; set; }
    public AccessPackageResource[]? Resources { get; set; }
}
