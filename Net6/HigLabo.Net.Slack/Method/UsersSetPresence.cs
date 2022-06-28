
namespace HigLabo.Net.Slack
{
    public class UsersSetPresenceParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.setPresence";
        public string HttpMethod { get; private set; } = "POST";
        public string Presence { get; set; } = "";
    }
    public partial class UsersSetPresenceResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(string presence)
        {
            var p = new UsersSetPresenceParameter();
            p.Presence = presence;
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(p, CancellationToken.None);
        }
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(string presence, CancellationToken cancellationToken)
        {
            var p = new UsersSetPresenceParameter();
            p.Presence = presence;
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(p, cancellationToken);
        }
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(UsersSetPresenceParameter parameter)
        {
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersSetPresenceResponse> UsersSetPresenceAsync(UsersSetPresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersSetPresenceParameter, UsersSetPresenceResponse>(parameter, cancellationToken);
        }
    }
}
