using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-dispositionreviewstage?view=graph-rest-1.0
/// </summary>
public partial class DispositionReviewStage
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public String[]? ReviewersEmailAddresses { get; set; }
    public string? StageNumber { get; set; }
}
