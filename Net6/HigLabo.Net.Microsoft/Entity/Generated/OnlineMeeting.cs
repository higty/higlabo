using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/onlinemeeting?view=graph-rest-1.0
    /// </summary>
    public partial class OnlineMeeting
    {
        public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        public bool AllowAttendeeToEnableCamera { get; set; }
        public bool AllowAttendeeToEnableMic { get; set; }
        public MeetingChatMode? AllowMeetingChat { get; set; }
        public bool AllowTeamworkReactions { get; set; }
        public Stream? AttendeeReport { get; set; }
        public AudioConferencing? AudioConferencing { get; set; }
        public BroadcastMeetingSettings? BroadcastSettings { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string Id { get; set; }
        public bool IsBroadcast { get; set; }
        public bool IsEntryExitAnnounced { get; set; }
        public ItemBody? JoinInformation { get; set; }
        public string JoinWebUrl { get; set; }
        public LobbyBypassSettings? LobbyBypassSettings { get; set; }
        public MeetingParticipants? Participants { get; set; }
        public bool RecordAutomatically { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string Subject { get; set; }
        public string VideoTeleconferenceId { get; set; }
    }
}
