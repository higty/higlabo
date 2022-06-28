
namespace HigLabo.Net.Slack
{
    public class UsersProfileGetParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.profile.get";
        public string HttpMethod { get; private set; } = "GET";
        public bool? Include_Labels { get; set; }
        public string User { get; set; } = "";
    }
    public partial class UsersProfileGetResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersProfileGetResponse> UsersProfileGetAsync()
        {
            var p = new UsersProfileGetParameter();
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(p, CancellationToken.None);
        }
        public async Task<UsersProfileGetResponse> UsersProfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new UsersProfileGetParameter();
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(p, cancellationToken);
        }
        public async Task<UsersProfileGetResponse> UsersProfileGetAsync(UsersProfileGetParameter parameter)
        {
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersProfileGetResponse> UsersProfileGetAsync(UsersProfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(parameter, cancellationToken);
        }
    }
}
