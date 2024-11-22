using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/learningassignment?view=graph-rest-1.0
/// </summary>
public partial class LearningAssignment
{
    public enum LearningAssignmentCourseStatus
    {
        NotStarted,
        InProgress,
        Completed,
    }

    public DateTimeOffset? AssignedDateTime { get; set; }
    public string? AssignerUserId { get; set; }
    public string? AssignmentType { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public Int32? CompletionPercentage { get; set; }
    public DateTimeOffset? DueDateTime { get; set; }
    public string? ExternalCourseActivityId { get; set; }
    public string? Id { get; set; }
    public string? LearnerUserId { get; set; }
    public string? LearningContentId { get; set; }
    public string? LearningProviderId { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset? StartedDateTime { get; set; }
    public LearningAssignmentCourseStatus Status { get; set; }
}
