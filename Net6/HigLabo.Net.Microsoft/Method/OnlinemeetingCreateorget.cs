using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnlinemeetingCreateorgetParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OnlineMeetings_CreateOrGet: return $"/me/onlineMeetings/createOrGet";
                    case ApiPath.Users_UserId_OnlineMeetings_CreateOrGet: return $"/users/{UserId}/onlineMeetings/createOrGet";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_OnlineMeetings_CreateOrGet,
            Users_UserId_OnlineMeetings_CreateOrGet,
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
        public DateTime? EndDateTime { get; set; }
        public string? ExternalId { get; set; }
        public MeetingParticipants? Participants { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string? Subject { get; set; }
        public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        public bool? AllowAttendeeToEnableCamera { get; set; }
        public bool? AllowAttendeeToEnableMic { get; set; }
        public MeetingChatMode? AllowMeetingChat { get; set; }
        public bool? AllowTeamworkReactions { get; set; }
        public Stream? AttendeeReport { get; set; }
        public AudioConferencing? AudioConferencing { get; set; }
        public BroadcastMeetingSettings? BroadcastSettings { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsBroadcast { get; set; }
        public bool? IsEntryExitAnnounced { get; set; }
        public ItemBody? JoinInformation { get; set; }
        public string? JoinWebUrl { get; set; }
        public LobbyBypassSettings? LobbyBypassSettings { get; set; }
        public bool? RecordAutomatically { get; set; }
        public string? VideoTeleconferenceId { get; set; }
        public MeetingAttendanceReport[]? AttendanceReports { get; set; }
    }
    public partial class OnlinemeetingCreateorgetResponse : RestApiResponse
    {
        public OnlineMeetingPresenters? AllowedPresenters { get; set; }
        public bool? AllowAttendeeToEnableCamera { get; set; }
        public bool? AllowAttendeeToEnableMic { get; set; }
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
        public string? JoinWebUrl { get; set; }
        public LobbyBypassSettings? LobbyBypassSettings { get; set; }
        public MeetingParticipants? Participants { get; set; }
        public bool? RecordAutomatically { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string? Subject { get; set; }
        public string? VideoTeleconferenceId { get; set; }
        public MeetingAttendanceReport[]? AttendanceReports { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-createorget?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingCreateorgetResponse> OnlinemeetingCreateorgetAsync()
        {
            var p = new OnlinemeetingCreateorgetParameter();
            return await this.SendAsync<OnlinemeetingCreateorgetParameter, OnlinemeetingCreateorgetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-createorget?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingCreateorgetResponse> OnlinemeetingCreateorgetAsync(CancellationToken cancellationToken)
        {
            var p = new OnlinemeetingCreateorgetParameter();
            return await this.SendAsync<OnlinemeetingCreateorgetParameter, OnlinemeetingCreateorgetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-createorget?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingCreateorgetResponse> OnlinemeetingCreateorgetAsync(OnlinemeetingCreateorgetParameter parameter)
        {
            return await this.SendAsync<OnlinemeetingCreateorgetParameter, OnlinemeetingCreateorgetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-createorget?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingCreateorgetResponse> OnlinemeetingCreateorgetAsync(OnlinemeetingCreateorgetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnlinemeetingCreateorgetParameter, OnlinemeetingCreateorgetResponse>(parameter, cancellationToken);
        }
    }
}
