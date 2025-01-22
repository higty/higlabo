using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/projectrome-historyitem?view=graph-rest-1.0
/// </summary>
public partial class HistoryItem
{
    public int? ActiveDurationSeconds { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActiveDateTime { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DateTimeOffset? StartedDateTime { get; set; }
    public Status? Status { get; set; }
    public string? UserTimezone { get; set; }
    public Activity? Activity { get; set; }
}
