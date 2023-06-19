using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class UsersProfileGetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.profile.get";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool? Include_Labels { get; set; }
        public string? User { get; set; }
    }
    public partial class UsersProfileGetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/users.profile.get
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/users.profile.get
        /// </summary>
        public async ValueTask<UsersProfileGetResponse> UsersProfileGetAsync()
        {
            var p = new UsersProfileGetParameter();
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.profile.get
        /// </summary>
        public async ValueTask<UsersProfileGetResponse> UsersProfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new UsersProfileGetParameter();
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.profile.get
        /// </summary>
        public async ValueTask<UsersProfileGetResponse> UsersProfileGetAsync(UsersProfileGetParameter parameter)
        {
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.profile.get
        /// </summary>
        public async ValueTask<UsersProfileGetResponse> UsersProfileGetAsync(UsersProfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersProfileGetParameter, UsersProfileGetResponse>(parameter, cancellationToken);
        }
    }
}
