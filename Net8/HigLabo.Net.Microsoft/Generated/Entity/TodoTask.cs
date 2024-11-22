using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/todotask?view=graph-rest-1.0
/// </summary>
public partial class TodoTask
{
    public enum TodoTaskImportance
    {
        Low,
        Normal,
        High,
    }
    public enum TodoTaskTaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        WaitingOnOthers,
        Deferred,
    }

    public ItemBody? Body { get; set; }
    public DateTimeOffset? BodyLastModifiedDateTime { get; set; }
    public String[]? Categories { get; set; }
    public DateTimeTimeZone? CompletedDateTime { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public DateTimeTimeZone? DueDateTime { get; set; }
    public bool? HasAttachments { get; set; }
    public string? Id { get; set; }
    public TodoTaskImportance Importance { get; set; }
    public bool? IsReminderOn { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public PatternedRecurrence? Recurrence { get; set; }
    public DateTimeTimeZone? ReminderDateTime { get; set; }
    public DateTimeTimeZone? StartDateTime { get; set; }
    public TodoTaskTaskStatus Status { get; set; }
    public string? Title { get; set; }
    public TaskFileAttachment[]? Attachments { get; set; }
    public ChecklistItem[]? ChecklistItems { get; set; }
    public Extension[]? Extensions { get; set; }
    public LinkedResource[]? LinkedResources { get; set; }
}
