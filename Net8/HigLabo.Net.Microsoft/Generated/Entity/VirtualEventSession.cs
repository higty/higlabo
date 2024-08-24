using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventsession?view=graph-rest-1.0
    /// </summary>
    public partial class VirtualEventSession
    {
        public enum VirtualEventSessionOnlineMeetingRole
        {
            Attendee,
        }

        public bool? AllowAttendeeToEnableCamera { get; set; }
        public bool? AllowAttendeeToEnableMic { get; set; }
        public MeetingChatMode? AllowMeetingChat { get; set; }
        public bool? AllowParticipantsToChangeName { get; set; }
        public bool? AllowTeamworkReactions { get; set; }
        public bool? AllowTranscription { get; set; }
        public bool? AllowRecording { get; set; }
        public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        public VirtualEventSessionOnlineMeetingRole AnonymizeIdentityForRoles { get; set; }
        public AudioConferencing? AudioConferencing { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public DateTimeTimeZone? EndDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsEntryExitAnnounced { get; set; }
        public ItemBody? JoinInformation { get; set; }
        public JoinMeetingIdSettings? JoinMeetingIdSettings { get; set; }
        public string? JoinWebUrl { get; set; }
        public LobbyBypassSettings? LobbyBypassSettings { get; set; }
        public bool? RecordAutomatically { get; set; }
        public DateTimeTimeZone? StartDateTime { get; set; }
        public string? Subject { get; set; }
        public string? VideoTeleconferenceId { get; set; }
        public WatermarkProtectionValues? WatermarkProtection { get; set; }
        public MeetingAttendanceReport[]? AttendanceReports { get; set; }
    }
}
