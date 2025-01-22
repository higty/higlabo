using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
/// </summary>
public partial class ParticipantStopholdMusicParameter : IRestApiParameter
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
                case ApiPath.Communications_Calls_Id_Participants_Id_StopHoldMusic: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}/stopHoldMusic";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Communications_Calls_Id_Participants_Id_StopHoldMusic,
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
    public string? ClientContext { get; set; }
    public string? Id { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public string? Status { get; set; }
}
public partial class ParticipantStopholdMusicResponse : RestApiResponse
{
    public string? ClientContext { get; set; }
    public string? Id { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public string? Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantStopholdMusicResponse> ParticipantStopholdMusicAsync()
    {
        var p = new ParticipantStopholdMusicParameter();
        return await this.SendAsync<ParticipantStopholdMusicParameter, ParticipantStopholdMusicResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantStopholdMusicResponse> ParticipantStopholdMusicAsync(CancellationToken cancellationToken)
    {
        var p = new ParticipantStopholdMusicParameter();
        return await this.SendAsync<ParticipantStopholdMusicParameter, ParticipantStopholdMusicResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantStopholdMusicResponse> ParticipantStopholdMusicAsync(ParticipantStopholdMusicParameter parameter)
    {
        return await this.SendAsync<ParticipantStopholdMusicParameter, ParticipantStopholdMusicResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ParticipantStopholdMusicResponse> ParticipantStopholdMusicAsync(ParticipantStopholdMusicParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ParticipantStopholdMusicParameter, ParticipantStopholdMusicResponse>(parameter, cancellationToken);
    }
}
