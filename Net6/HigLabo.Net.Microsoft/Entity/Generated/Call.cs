using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/call?view=graph-rest-1.0
    /// </summary>
    public partial class Call
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
}
