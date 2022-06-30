
namespace HigLabo.Net.Slack
{
    public partial class UsersSetPresenceParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.setPresence";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Presence { get; set; }
    }
    public partial class UsersSetPresenceResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/users.setPresence
        /// </summary>
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(string presence)
        {
            var p = new UsersSetPresenceParameter();
            p.Presence = presence;
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.setPresence
        /// </summary>
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(string presence, CancellationToken cancellationToken)
        {
            var p = new UsersSetPresenceParameter();
            p.Presence = presence;
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.setPresence
        /// </summary>
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(UsersSetPresenceParameter parameter)
        {
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.setPresence
        /// </summary>
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(UsersSetPresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(parameter, cancellationToken);
        }
    }
}
