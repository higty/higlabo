using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/reminders.delete
    /// </summary>
    public partial class RemindersDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reminders.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Reminder { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class RemindersDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/reminders.delete
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/reminders.delete
        /// </summary>
        public async ValueTask<RemindersDeleteResponse> RemindersDeleteAsync(string? reminder)
        {
            var p = new RemindersDeleteParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.delete
        /// </summary>
        public async ValueTask<RemindersDeleteResponse> RemindersDeleteAsync(string? reminder, CancellationToken cancellationToken)
        {
            var p = new RemindersDeleteParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.delete
        /// </summary>
        public async ValueTask<RemindersDeleteResponse> RemindersDeleteAsync(RemindersDeleteParameter parameter)
        {
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.delete
        /// </summary>
        public async ValueTask<RemindersDeleteResponse> RemindersDeleteAsync(RemindersDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(parameter, cancellationToken);
        }
    }
}
