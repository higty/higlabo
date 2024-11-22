using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewhistorydefinition?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewHistoryDefinition
{
    public enum AccessReviewHistoryDefinitionAccessReviewHistoryStatus
    {
        Done,
        InProgress,
        Error,
        Requested,
        UnknownFutureValue,
    }

    public UserIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public String[]? Decisions { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
    public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
    public AccessReviewHistoryScheduleSettings? ScheduleSettings { get; set; }
    public AccessReviewScope[]? Scopes { get; set; }
    public AccessReviewHistoryDefinitionAccessReviewHistoryStatus Status { get; set; }
    public AccessReviewHistoryInstance[]? Instances { get; set; }
}
