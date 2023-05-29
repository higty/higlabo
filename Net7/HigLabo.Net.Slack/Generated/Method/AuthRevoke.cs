using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AuthRevokeParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "auth.revoke";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool? Test { get; set; }
    }
    public partial class AuthRevokeResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/auth.revoke
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/auth.revoke
        /// </summary>
        public async Task<AuthRevokeResponse> AuthRevokeAsync()
        {
            var p = new AuthRevokeParameter();
            return await this.SendAsync<AuthRevokeParameter, AuthRevokeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/auth.revoke
        /// </summary>
        public async Task<AuthRevokeResponse> AuthRevokeAsync(CancellationToken cancellationToken)
        {
            var p = new AuthRevokeParameter();
            return await this.SendAsync<AuthRevokeParameter, AuthRevokeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/auth.revoke
        /// </summary>
        public async Task<AuthRevokeResponse> AuthRevokeAsync(AuthRevokeParameter parameter)
        {
            return await this.SendAsync<AuthRevokeParameter, AuthRevokeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/auth.revoke
        /// </summary>
        public async Task<AuthRevokeResponse> AuthRevokeAsync(AuthRevokeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthRevokeParameter, AuthRevokeResponse>(parameter, cancellationToken);
        }
    }
}
