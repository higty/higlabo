
namespace HigLabo.Net.Slack
{
    public partial class RemindersInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reminders.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Reminder { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class RemindersInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RemindersInfoResponse> RemindersInfoAsync(string reminder)
        {
            var p = new RemindersInfoParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersInfoParameter, RemindersInfoResponse>(p, CancellationToken.None);
        }
        public async Task<RemindersInfoResponse> RemindersInfoAsync(string reminder, CancellationToken cancellationToken)
        {
            var p = new RemindersInfoParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersInfoParameter, RemindersInfoResponse>(p, cancellationToken);
        }
        public async Task<RemindersInfoResponse> RemindersInfoAsync(RemindersInfoParameter parameter)
        {
            return await this.SendAsync<RemindersInfoParameter, RemindersInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<RemindersInfoResponse> RemindersInfoAsync(RemindersInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersInfoParameter, RemindersInfoResponse>(parameter, cancellationToken);
        }
    }
}
