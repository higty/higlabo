
namespace HigLabo.Net.Slack
{
    public class UsersGetPresenceParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.getPresence";
        public string HttpMethod { get; private set; } = "GET";
        public string User { get; set; } = "";
    }
    public partial class UsersGetPresenceResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync()
        {
            var p = new UsersGetPresenceParameter();
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(p, CancellationToken.None);
        }
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync(CancellationToken cancellationToken)
        {
            var p = new UsersGetPresenceParameter();
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(p, cancellationToken);
        }
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync(UsersGetPresenceParameter parameter)
        {
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersGetPresenceResponse> UsersGetPresenceAsync(UsersGetPresenceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersGetPresenceParameter, UsersGetPresenceResponse>(parameter, cancellationToken);
        }
    }
}
