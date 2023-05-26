using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-update?view=graph-rest-1.0
    /// </summary>
    public partial class OnlinemeetingUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? MeetingId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OnlineMeetings_MeetingId: return $"/me/onlineMeetings/{MeetingId}";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId: return $"/users/{UserId}/onlineMeetings/{MeetingId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId,
            Users_UserId_OnlineMeetings_MeetingId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? Subject { get; set; }
        public MeetingParticipants? Participants { get; set; }
        public bool? IsEntryExitAnnounced { get; set; }
        public LobbyBypassSettings? LobbyBypassSettings { get; set; }
        public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        public bool? AllowAttendeeToEnableCamera { get; set; }
        public bool? AllowAttendeeToEnableMic { get; set; }
        public MeetingChatMode? AllowMeetingChat { get; set; }
        public bool? AllowTeamworkReactions { get; set; }
    }
    public partial class OnlinemeetingUpdateResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingUpdateResponse> OnlinemeetingUpdateAsync()
        {
            var p = new OnlinemeetingUpdateParameter();
            return await this.SendAsync<OnlinemeetingUpdateParameter, OnlinemeetingUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingUpdateResponse> OnlinemeetingUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OnlinemeetingUpdateParameter();
            return await this.SendAsync<OnlinemeetingUpdateParameter, OnlinemeetingUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingUpdateResponse> OnlinemeetingUpdateAsync(OnlinemeetingUpdateParameter parameter)
        {
            return await this.SendAsync<OnlinemeetingUpdateParameter, OnlinemeetingUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingUpdateResponse> OnlinemeetingUpdateAsync(OnlinemeetingUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnlinemeetingUpdateParameter, OnlinemeetingUpdateResponse>(parameter, cancellationToken);
        }
    }
}
