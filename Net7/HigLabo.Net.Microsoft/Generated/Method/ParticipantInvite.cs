using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
    /// </summary>
    public partial class ParticipantInviteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Invite: return $"/communications/calls/{Id}/participants/invite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Invite,
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
        public InvitationParticipantInfo[]? Participants { get; set; }
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class ParticipantInviteResponse : RestApiResponse
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public InvitationParticipantInfo[]? Participants { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantInviteResponse> ParticipantInviteAsync()
        {
            var p = new ParticipantInviteParameter();
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantInviteResponse> ParticipantInviteAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantInviteParameter();
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantInviteResponse> ParticipantInviteAsync(ParticipantInviteParameter parameter)
        {
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-invite?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ParticipantInviteResponse> ParticipantInviteAsync(ParticipantInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantInviteParameter, ParticipantInviteResponse>(parameter, cancellationToken);
        }
    }
}
