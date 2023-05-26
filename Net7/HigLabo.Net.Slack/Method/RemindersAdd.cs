using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class RemindersAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reminders.add";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Text { get; set; }
        public string? Time { get; set; }
        public Recurrence Recurrence { get; set; }
        public string? Team_Id { get; set; }
        public string? User { get; set; }
    }
    public partial class RemindersAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/reminders.add
        /// </summary>
        public async Task<RemindersAddResponse> RemindersAddAsync(string? text, string? time)
        {
            var p = new RemindersAddParameter();
            p.Text = text;
            p.Time = time;
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.add
        /// </summary>
        public async Task<RemindersAddResponse> RemindersAddAsync(string? text, string? time, CancellationToken cancellationToken)
        {
            var p = new RemindersAddParameter();
            p.Text = text;
            p.Time = time;
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.add
        /// </summary>
        public async Task<RemindersAddResponse> RemindersAddAsync(RemindersAddParameter parameter)
        {
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reminders.add
        /// </summary>
        public async Task<RemindersAddResponse> RemindersAddAsync(RemindersAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(parameter, cancellationToken);
        }
    }
}
