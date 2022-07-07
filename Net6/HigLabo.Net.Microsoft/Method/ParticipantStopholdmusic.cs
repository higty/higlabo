using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ParticipantStopholdmusicParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Id_StopHoldMusic,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Id_StopHoldMusic: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}/stopHoldMusic";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ClientContext { get; set; }
        public string CallsId { get; set; }
        public string ParticipantsId { get; set; }
    }
    public partial class ParticipantStopholdmusicResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantStopholdmusicResponse> ParticipantStopholdmusicAsync()
        {
            var p = new ParticipantStopholdmusicParameter();
            return await this.SendAsync<ParticipantStopholdmusicParameter, ParticipantStopholdmusicResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantStopholdmusicResponse> ParticipantStopholdmusicAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantStopholdmusicParameter();
            return await this.SendAsync<ParticipantStopholdmusicParameter, ParticipantStopholdmusicResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantStopholdmusicResponse> ParticipantStopholdmusicAsync(ParticipantStopholdmusicParameter parameter)
        {
            return await this.SendAsync<ParticipantStopholdmusicParameter, ParticipantStopholdmusicResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-stopholdmusic?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantStopholdmusicResponse> ParticipantStopholdmusicAsync(ParticipantStopholdmusicParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantStopholdmusicParameter, ParticipantStopholdmusicResponse>(parameter, cancellationToken);
        }
    }
}
