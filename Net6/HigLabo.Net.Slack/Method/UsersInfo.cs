
namespace HigLabo.Net.Slack
{
    public class UsersInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.info";
        public string HttpMethod { get; private set; } = "GET";
        public string User { get; set; } = "";
        public bool? Include_Locale { get; set; }
    }
    public partial class UsersInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersInfoResponse> UsersInfoAsync(string user)
        {
            var p = new UsersInfoParameter();
            p.User = user;
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(p, CancellationToken.None);
        }
        public async Task<UsersInfoResponse> UsersInfoAsync(string user, CancellationToken cancellationToken)
        {
            var p = new UsersInfoParameter();
            p.User = user;
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(p, cancellationToken);
        }
        public async Task<UsersInfoResponse> UsersInfoAsync(UsersInfoParameter parameter)
        {
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersInfoResponse> UsersInfoAsync(UsersInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(parameter, cancellationToken);
        }
    }
}
