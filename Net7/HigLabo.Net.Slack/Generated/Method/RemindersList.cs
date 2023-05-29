using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class RemindersListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reminders.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Team_Id { get; set; }
    }
    public partial class RemindersListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/reminders.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/reminders.list
        /// </summary>
        public async Task<RemindersListResponse> RemindersListAsync()
        {
            var p = new RemindersListParameter();
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.list
        /// </summary>
        public async Task<RemindersListResponse> RemindersListAsync(CancellationToken cancellationToken)
        {
            var p = new RemindersListParameter();
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.list
        /// </summary>
        public async Task<RemindersListResponse> RemindersListAsync(RemindersListParameter parameter)
        {
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.list
        /// </summary>
        public async Task<RemindersListResponse> RemindersListAsync(RemindersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(parameter, cancellationToken);
        }
    }
}
