using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-startholdmusic?view=graph-rest-1.0
    /// </summary>
    public partial class ParticipantStartholdMusicParameter : IRestApiParameter
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
                    case ApiPath.Communications_Calls_Id_Participants_Id_StartHoldMusic: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}/startHoldMusic";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Id_StartHoldMusic,
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
        public MediaPrompt? CustomPrompt { get; set; }
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class ParticipantStartholdMusicResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-startholdmusic?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-startholdmusic?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantStartholdMusicResponse> ParticipantStartholdMusicAsync()
        {
            var p = new ParticipantStartholdMusicParameter();
            return await this.SendAsync<ParticipantStartholdMusicParameter, ParticipantStartholdMusicResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-startholdmusic?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantStartholdMusicResponse> ParticipantStartholdMusicAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantStartholdMusicParameter();
            return await this.SendAsync<ParticipantStartholdMusicParameter, ParticipantStartholdMusicResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-startholdmusic?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantStartholdMusicResponse> ParticipantStartholdMusicAsync(ParticipantStartholdMusicParameter parameter)
        {
            return await this.SendAsync<ParticipantStartholdMusicParameter, ParticipantStartholdMusicResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-startholdmusic?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantStartholdMusicResponse> ParticipantStartholdMusicAsync(ParticipantStartholdMusicParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantStartholdMusicParameter, ParticipantStartholdMusicResponse>(parameter, cancellationToken);
        }
    }
}
