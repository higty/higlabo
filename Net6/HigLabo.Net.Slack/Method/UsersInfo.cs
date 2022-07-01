using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class UsersInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string User { get; set; }
        public bool? Include_Locale { get; set; }
    }
    public partial class UsersInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/users.info
        /// </summary>
        public async Task<UsersInfoResponse> UsersInfoAsync(string user)
        {
            var p = new UsersInfoParameter();
            p.User = user;
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.info
        /// </summary>
        public async Task<UsersInfoResponse> UsersInfoAsync(string user, CancellationToken cancellationToken)
        {
            var p = new UsersInfoParameter();
            p.User = user;
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.info
        /// </summary>
        public async Task<UsersInfoResponse> UsersInfoAsync(UsersInfoParameter parameter)
        {
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.info
        /// </summary>
        public async Task<UsersInfoResponse> UsersInfoAsync(UsersInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersInfoParameter, UsersInfoResponse>(parameter, cancellationToken);
        }
    }
}
