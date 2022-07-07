using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostCallsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls: return $"/communications/calls";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public CallRoute[]? CallRoutes { get; set; }
        public ChatInfo? ChatInfo { get; set; }
        public CallCallDirection Direction { get; set; }
        public string? Id { get; set; }
        public AppHostedMediaConfig? MediaConfig { get; set; }
        public CallMediaState? MediaState { get; set; }
        public OrganizerMeetingInfo? MeetingInfo { get; set; }
        public CallTranscriptionInfo? Transcription { get; set; }
        public string? MyParticipantId { get; set; }
        public CallModality RequestedModalities { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public ParticipantInfo? Source { get; set; }
        public CallCallState State { get; set; }
        public string? Subject { get; set; }
        public ParticipantInfo[]? Targets { get; set; }
        public ToneInfo? ToneInfo { get; set; }
        public IncomingContext? IncomingContext { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync()
        {
            var p = new ApplicationPostCallsParameter();
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostCallsParameter();
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync(ApplicationPostCallsParameter parameter)
        {
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-calls?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostCallsResponse> ApplicationPostCallsAsync(ApplicationPostCallsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostCallsParameter, ApplicationPostCallsResponse>(parameter, cancellationToken);
        }
    }
}
