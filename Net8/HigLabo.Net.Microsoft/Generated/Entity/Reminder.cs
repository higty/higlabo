using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/reminder?view=graph-rest-1.0
/// </summary>
public partial class Reminder
{
    public string? ChangeKey { get; set; }
    public DateTimeTimeZone? EventEndTime { get; set; }
    public string? EventId { get; set; }
    public Location? EventLocation { get; set; }
    public DateTimeTimeZone? EventStartTime { get; set; }
    public string? EventSubject { get; set; }
    public string? EventWebLink { get; set; }
    public DateTimeTimeZone? ReminderFireTime { get; set; }
}
