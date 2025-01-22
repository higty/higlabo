using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/educationteamsappresource?view=graph-rest-1.0
/// </summary>
public partial class EducationTeamsAppResource
{
    public string? AppIconWebUrl { get; set; }
    public string? AppId { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? TeamsEmbeddedContentUrl { get; set; }
    public string? WebUrl { get; set; }
}
