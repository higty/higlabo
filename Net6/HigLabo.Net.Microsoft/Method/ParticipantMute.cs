using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ParticipantMuteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Id_Mute,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Id_Mute: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}/mute";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientContext { get; set; }
        public string CallsId { get; set; }
        public string ParticipantsId { get; set; }
    }
    public partial class ParticipantMuteResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantMuteResponse> ParticipantMuteAsync()
        {
            var p = new ParticipantMuteParameter();
            return await this.SendAsync<ParticipantMuteParameter, ParticipantMuteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantMuteResponse> ParticipantMuteAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantMuteParameter();
            return await this.SendAsync<ParticipantMuteParameter, ParticipantMuteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantMuteResponse> ParticipantMuteAsync(ParticipantMuteParameter parameter)
        {
            return await this.SendAsync<ParticipantMuteParameter, ParticipantMuteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-mute?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantMuteResponse> ParticipantMuteAsync(ParticipantMuteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantMuteParameter, ParticipantMuteResponse>(parameter, cancellationToken);
        }
    }
}
