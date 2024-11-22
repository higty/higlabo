using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
/// </summary>
public partial class ParticipantGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? CallsId { get; set; }
        public string? ParticipantsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Communications_Calls_Id_Participants_Id: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Communications_Calls_Id_Participants_Id,
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
public partial class ParticipantGetResponse : RestApiResponse
{
    public string? Id { get; set; }
    public ParticipantInfo? Info { get; set; }
    public bool? IsInLobby { get; set; }
    public bool? IsMuted { get; set; }
    public MediaStream[]? MediaStreams { get; set; }
    public string? Metadata { get; set; }
    public RecordingInfo? RecordingInfo { get; set; }
    public OnlineMeetingRestricted? RestrictedExperience { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantGetResponse> ParticipantGetAsync()
    {
        var p = new ParticipantGetParameter();
        return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantGetResponse> ParticipantGetAsync(CancellationToken cancellationToken)
    {
        var p = new ParticipantGetParameter();
        return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantGetResponse> ParticipantGetAsync(ParticipantGetParameter parameter)
    {
        return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantGetResponse> ParticipantGetAsync(ParticipantGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ParticipantGetParameter, ParticipantGetResponse>(parameter, cancellationToken);
    }
}
