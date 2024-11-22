using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-get?view=graph-rest-1.0
/// </summary>
public partial class CallGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Communications_Calls_Id: return $"/communications/calls/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Communications_Calls_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class CallGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/call-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallGetResponse> CallGetAsync()
    {
        var p = new CallGetParameter();
        return await this.SendAsync<CallGetParameter, CallGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallGetResponse> CallGetAsync(CancellationToken cancellationToken)
    {
        var p = new CallGetParameter();
        return await this.SendAsync<CallGetParameter, CallGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallGetResponse> CallGetAsync(CallGetParameter parameter)
    {
        return await this.SendAsync<CallGetParameter, CallGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallGetResponse> CallGetAsync(CallGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CallGetParameter, CallGetResponse>(parameter, cancellationToken);
    }
}
