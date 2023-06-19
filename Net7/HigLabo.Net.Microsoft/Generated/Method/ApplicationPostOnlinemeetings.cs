using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationPostOnlinemeetingsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OnlineMeetings: return $"/me/onlineMeetings";
                    case ApiPath.Users_UserId_OnlineMeetings: return $"/users/{UserId}/onlineMeetings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_OnlineMeetings,
            Users_UserId_OnlineMeetings,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class ApplicationPostOnlinemeetingsResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync()
        {
            var p = new ApplicationPostOnlinemeetingsParameter();
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostOnlinemeetingsParameter();
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync(ApplicationPostOnlinemeetingsParameter parameter)
        {
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync(ApplicationPostOnlinemeetingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(parameter, cancellationToken);
        }
    }
}
