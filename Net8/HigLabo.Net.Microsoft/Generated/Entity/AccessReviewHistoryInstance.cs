using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewhistoryinstance?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewHistoryInstance
{
    public enum AccessReviewHistoryInstanceAccessReviewHistoryStatus
    {
        Done,
        InProgress,
        Error,
        Requested,
        UnknownFutureValue,
    }

    public string? DownloadUri { get; set; }
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public DateTimeOffset? FulfilledDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
    public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
    public DateTimeOffset? RunDateTime { get; set; }
    public AccessReviewHistoryInstanceAccessReviewHistoryStatus Status { get; set; }
}
