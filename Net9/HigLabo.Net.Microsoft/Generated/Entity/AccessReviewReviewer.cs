using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewreviewer?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewReviewer
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? UserPrincipalName { get; set; }
}
