using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/meetingtimesuggestion?view=graph-rest-1.0
    /// </summary>
    public partial class MeetingTimeSuggestion
    {
        public enum MeetingTimeSuggestionFreeBusyStatus
        {
            Free,
            Tentative,
            Busy,
            Oof,
            WorkingElsewhere,
            Unknown,
        }

        public AttendeeAvailability[]? AttendeeAvailability { get; set; }
        public Double? Confidence { get; set; }
        public Location[]? Locations { get; set; }
        public TimeSlot? MeetingTimeSlot { get; set; }
        public Int32? Order { get; set; }
        public MeetingTimeSuggestionFreeBusyStatus OrganizerAvailability { get; set; }
        public string? SuggestionReason { get; set; }
    }
}
