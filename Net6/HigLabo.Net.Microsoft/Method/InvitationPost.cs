using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
    /// </summary>
    public partial class InvitationPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Invitations: return $"/invitations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Invitations,
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
        public string? InvitedUserEmailAddress { get; set; }
        public string? InviteRedirectUrl { get; set; }
        public string? InvitedUserDisplayName { get; set; }
        public InvitedUserMessageInfo? InvitedUserMessageInfo { get; set; }
        public string? InvitedUserType { get; set; }
        public string? InviteRedeemUrl { get; set; }
        public bool? ResetRedemption { get; set; }
        public bool? SendInvitationMessage { get; set; }
        public string? Status { get; set; }
        public User? InvitedUser { get; set; }
    }
    public partial class InvitationPostResponse : RestApiResponse
    {
        public string? InvitedUserDisplayName { get; set; }
        public string? InvitedUserEmailAddress { get; set; }
        public InvitedUserMessageInfo? InvitedUserMessageInfo { get; set; }
        public string? InvitedUserType { get; set; }
        public string? InviteRedirectUrl { get; set; }
        public string? InviteRedeemUrl { get; set; }
        public bool? ResetRedemption { get; set; }
        public bool? SendInvitationMessage { get; set; }
        public string? Status { get; set; }
        public User? InvitedUser { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync()
        {
            var p = new InvitationPostParameter();
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync(CancellationToken cancellationToken)
        {
            var p = new InvitationPostParameter();
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync(InvitationPostParameter parameter)
        {
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/invitation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<InvitationPostResponse> InvitationPostAsync(InvitationPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InvitationPostParameter, InvitationPostResponse>(parameter, cancellationToken);
        }
    }
}
