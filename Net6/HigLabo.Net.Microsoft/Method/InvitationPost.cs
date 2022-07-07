using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InvitationPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Invitations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Invitations: return $"/invitations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? InvitedUserEmailAddress { get; set; }
        public string? InviteRedirectUrl { get; set; }
    }
    public partial class InvitationPostResponse : RestApiResponse
    {
        public string? InvitedUserDisplayName { get; set; }
        public string? InvitedUserEmailAddress { get; set; }
        public Configuring? InvitedUserMessageInfo { get; set; }
        public bool? SendInvitationMessage { get; set; }
        public string? InviteRedirectUrl { get; set; }
        public string? InviteRedeemUrl { get; set; }
        public string? InvitedUserType { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync()
        {
            var p = new InvitationPostParameter();
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync(CancellationToken cancellationToken)
        {
            var p = new InvitationPostParameter();
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync(InvitationPostParameter parameter)
        {
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync(InvitationPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(parameter, cancellationToken);
        }
    }
}
