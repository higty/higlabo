using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostOnlinemeetingsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_OnlineMeetings,
            Users_UserId_OnlineMeetings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_OnlineMeetings: return $"/me/onlineMeetings";
                    case ApiPath.Users_UserId_OnlineMeetings: return $"/users/{UserId}/onlineMeetings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UserId { get; set; }
    }
    public partial class ApplicationPostOnlinemeetingsResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync()
        {
            var p = new ApplicationPostOnlinemeetingsParameter();
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostOnlinemeetingsParameter();
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync(ApplicationPostOnlinemeetingsParameter parameter)
        {
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-onlinemeetings?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOnlinemeetingsResponse> ApplicationPostOnlinemeetingsAsync(ApplicationPostOnlinemeetingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostOnlinemeetingsParameter, ApplicationPostOnlinemeetingsResponse>(parameter, cancellationToken);
        }
    }
}
