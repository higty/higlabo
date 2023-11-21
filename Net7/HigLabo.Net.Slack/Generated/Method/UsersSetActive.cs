using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/users.setActive
    /// </summary>
    public partial class UsersSetActiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.setActive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class UsersSetActiveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/users.setActive
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/users.setActive
        /// </summary>
        public async ValueTask<UsersSetActiveResponse> UsersSetActiveAsync()
        {
            var p = new UsersSetActiveParameter();
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.setActive
        /// </summary>
        public async ValueTask<UsersSetActiveResponse> UsersSetActiveAsync(CancellationToken cancellationToken)
        {
            var p = new UsersSetActiveParameter();
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.setActive
        /// </summary>
        public async ValueTask<UsersSetActiveResponse> UsersSetActiveAsync(UsersSetActiveParameter parameter)
        {
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.setActive
        /// </summary>
        public async ValueTask<UsersSetActiveResponse> UsersSetActiveAsync(UsersSetActiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersSetActiveParameter, UsersSetActiveResponse>(parameter, cancellationToken);
        }
    }
}
