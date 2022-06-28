
namespace HigLabo.Net.Slack
{
    public class UsersIdentityParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.identity";
        public string HttpMethod { get; private set; } = "GET";
    }
    public partial class UsersIdentityResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersIdentityResponse> UsersIdentityAsync()
        {
            var p = new UsersIdentityParameter();
            return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(p, CancellationToken.None);
        }
        public async Task<UsersIdentityResponse> UsersIdentityAsync(CancellationToken cancellationToken)
        {
            var p = new UsersIdentityParameter();
            return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(p, cancellationToken);
        }
        public async Task<UsersIdentityResponse> UsersIdentityAsync(UsersIdentityParameter parameter)
        {
            return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersIdentityResponse> UsersIdentityAsync(UsersIdentityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(parameter, cancellationToken);
        }
    }
}
