using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/automaticrepliesmailtips?view=graph-rest-1.0
/// </summary>
public partial class AutomaticRepliesMailTips
{
    public string? Message { get; set; }
    public LocaleInfo? MessageLanguage { get; set; }
    public DateTimeTimeZone? ScheduledEndTime { get; set; }
    public DateTimeTimeZone? ScheduledStartTime { get; set; }
}
