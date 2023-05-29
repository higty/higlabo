using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class UsersGetPresenceParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.getPresence";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? User { get; set; }
    }
    public partial class UsersGetPresenceResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/users.getPresence
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/users.getPresence
        /// </summary>
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync()
        {
            var p = new UsersGetPresenceParameter();
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.getPresence
        /// </summary>
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync(CancellationToken cancellationToken)
        {
            var p = new UsersGetPresenceParameter();
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.getPresence
        /// </summary>
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync(UsersGetPresenceParameter parameter)
        {
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.getPresence
        /// </summary>
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync(UsersGetPresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(parameter, cancellationToken);
        }
    }
}
