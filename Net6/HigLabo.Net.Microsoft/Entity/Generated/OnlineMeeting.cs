using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onlinemeeting?view=graph-rest-1.0
    /// </summary>
    public partial class OnlineMeeting
    {
        public bool? AllowAttendeeToEnableCamera { get; set; }
        public bool? AllowAttendeeToEnableMic { get; set; }
        public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        public MeetingChatMode? AllowMeetingChat { get; set; }
        public bool? AllowTeamworkReactions { get; set; }
        public Stream? AttendeeReport { get; set; }
        public AudioConferencing? AudioConferencing { get; set; }
        public BroadcastMeetingSettings? BroadcastSettings { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsBroadcast { get; set; }
        public bool? IsEntryExitAnnounced { get; set; }
        public ItemBody? JoinInformation { get; set; }
        public JoinMeetingIdSettings? JoinMeetingIdSettings { get; set; }
        public string? JoinWebUrl { get; set; }
        public LobbyBypassSettings? LobbyBypassSettings { get; set; }
        public MeetingParticipants? Participants { get; set; }
        public bool? RecordAutomatically { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string? Subject { get; set; }
        public string? VideoTeleconferenceId { get; set; }
        public WatermarkProtectionValues? WatermarkProtection { get; set; }
        public MeetingAttendanceReport[]? AttendanceReports { get; set; }
    }
}
