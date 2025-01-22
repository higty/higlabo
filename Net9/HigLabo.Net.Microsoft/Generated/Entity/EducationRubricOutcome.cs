using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/educationrubricoutcome?view=graph-rest-1.0
/// </summary>
public partial class EducationRubricOutcome
{
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public RubricQualityFeedbackModel[]? PublishedRubricQualityFeedback { get; set; }
    public RubricQualitySelectedColumnModel[]? PublishedRubricQualitySelectedLevels { get; set; }
    public RubricQualityFeedbackModel[]? RubricQualityFeedback { get; set; }
    public RubricQualitySelectedColumnModel[]? RubricQualitySelectedLevels { get; set; }
}
