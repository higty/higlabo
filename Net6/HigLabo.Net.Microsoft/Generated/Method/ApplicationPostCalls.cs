using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationPostCallsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls: return $"/communications/calls";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum CallCallDirection
        {
            Incoming,
            Outgoing,
        }
        public enum CallModality
        {
            Unknown,
            Audio,
            Video,
            VideoBasedScreenSharing,
            Data,
        }
        public enum CallCallState
        {
            Incoming,
            Establishing,
            Ringing,
            Established,
            Hold,
            Transferring,
            TransferAccepted,
            Redirecting,
            Terminating,
            Terminated,
        }
        public enum ApiPath
        {
            Communications_Calls,
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
        public string? CallbackUri { get; set; }
        public string? CallChainId { get; set; }
        public OutgoingCallOptions? CallOptions { get; set; }
        public CallRoute[]? CallRoutes { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public CallCallDirection Direction { get; set; }
        public string? Id { get; set; }
        public IncomingContext? IncomingContext { get; set; }
        public AppHostedMediaConfig? MediaConfig { get; set; }
        public CallMediaState? MediaState { get; set; }
        public OrganizerMeetingInfo? MeetingInfo { get; set; }
        public string? MyParticipantId { get; set; }
        public CallModality RequestedModalities { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public ParticipantInfo? Source { get; set; }
        public CallCallState State { get; set; }
        public string? Subject { get; set; }
        public ParticipantInfo[]? Targets { get; set; }
        public ToneInfo? ToneInfo { get; set; }
        public CallTranscriptionInfo? Transcription { get; set; }
        public ContentSharingSession[]? ContentSharingSessions { get; set; }
        public CommsOperation[]? Operations { get; set; }
        public Participant[]? Participants { get; set; }
    }
    public partial class ApplicationPostCallsResponse : RestApiResponse
    {
        public enum CallCallDirection
        {
            Incoming,
            Outgoing,
        }
        public enum CallModality
        {
            Unknown,
            Audio,
            Video,
            VideoBasedScreenSharing,
            Data,
        }
        public enum CallCallState
        {
            Incoming,
            Establishing,
            Ringing,
            Established,
            Hold,
            Transferring,
            TransferAccepted,
            Redirecting,
            Terminating,
            Terminated,
        }

        public string? CallbackUri { get; set; }
        public string? CallChainId { get; set; }
        public OutgoingCallOptions? CallOptions { get; set; }
        public CallRoute[]? CallRoutes { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public CallCallDirection Direction { get; set; }
        public string? Id { get; set; }
        public IncomingContext? IncomingContext { get; set; }
        public AppHostedMediaConfig? MediaConfig { get; set; }
        public CallMediaState? MediaState { get; set; }
        public OrganizerMeetingInfo? MeetingInfo { get; set; }
        public string? MyParticipantId { get; set; }
        public CallModality RequestedModalities { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public ParticipantInfo? Source { get; set; }
        public CallCallState State { get; set; }
        public string? Subject { get; set; }
        public ParticipantInfo[]? Targets { get; set; }
        public ToneInfo? ToneInfo { get; set; }
        public CallTranscriptionInfo? Transcription { get; set; }
        public ContentSharingSession[]? ContentSharingSessions { get; set; }
        public CommsOperation[]? Operations { get; set; }
        public Participant[]? Participants { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync()
        {
            var p = new ApplicationPostCallsParameter();
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostCallsParameter();
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync(ApplicationPostCallsParameter parameter)
        {
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync(ApplicationPostCallsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(parameter, cancellationToken);
        }
    }
}
