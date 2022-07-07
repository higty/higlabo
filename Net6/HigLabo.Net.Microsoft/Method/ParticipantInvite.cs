using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ParticipantInviteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Invite,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Invite: return $"/communications/calls/{Id}/participants/invite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public InvitationParticipantInfo[]? Participants { get; set; }
        public string? ClientContext { get; set; }
        public string Id { get; set; }
    }
    public partial class ParticipantInviteResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public InvitationParticipantInfo[]? Participants { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantInviteResponse> ParticipantInviteAsync()
        {
            var p = new ParticipantInviteParameter();
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantInviteResponse> ParticipantInviteAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantInviteParameter();
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantInviteResponse> ParticipantInviteAsync(ParticipantInviteParameter parameter)
        {
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantInviteResponse> ParticipantInviteAsync(ParticipantInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(parameter, cancellationToken);
        }
    }
}
