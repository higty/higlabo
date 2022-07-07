using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/event?view=graph-rest-1.0
    /// </summary>
    public partial class Event
    {
        public enum EventImportance
        {
            Low,
            Normal,
            High,
        }
        public enum EventOnlineMeetingProviderType
        {
            Unknown,
            TeamsForBusiness,
            SkypeForBusiness,
            SkypeForConsumer,
        }

        public bool? AllowNewTimeProposals { get; set; }
        public Attendee[]? Attendees { get; set; }
        public ItemBody? Body { get; set; }
        public string? BodyPreview { get; set; }
        public String[]? Categories { get; set; }
        public string? ChangeKey { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeTimeZone? End { get; set; }
        public bool? HasAttachments { get; set; }
        public bool? HideAttendees { get; set; }
        public string? ICalUId { get; set; }
        public string? Id { get; set; }
        public EventImportance Importance { get; set; }
        public bool? IsAllDay { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsOnlineMeeting { get; set; }
        public bool? IsOrganizer { get; set; }
        public bool? IsReminderOn { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Location? Location { get; set; }
        public Location[]? Locations { get; set; }
        public OnlineMeetingInfo? OnlineMeeting { get; set; }
        public EventOnlineMeetingProviderType OnlineMeetingProvider { get; set; }
        public string? OnlineMeetingUrl { get; set; }
        public Recipient? Organizer { get; set; }
        public string? OriginalEndTimeZone { get; set; }
        public DateTimeOffset? OriginalStart { get; set; }
        public string? OriginalStartTimeZone { get; set; }
        public PatternedRecurrence? Recurrence { get; set; }
        public Int32? ReminderMinutesBeforeStart { get; set; }
        public bool? ResponseRequested { get; set; }
        public ResponseStatus? ResponseStatus { get; set; }
        public string? Sensitivity { get; set; }
        public string? SeriesMasterId { get; set; }
        public string? ShowAs { get; set; }
        public DateTimeTimeZone? Start { get; set; }
        public string? Subject { get; set; }
        public string? TransactionId { get; set; }
        public string? Type { get; set; }
        public string? WebLink { get; set; }
    }
}
