
namespace HigLabo.Net.Slack
{
    public class RemindersCompleteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "reminders.complete";
        public string HttpMethod { get; private set; } = "POST";
        public string Reminder { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class RemindersCompleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RemindersCompleteResponse> RemindersCompleteAsync(string reminder)
        {
            var p = new RemindersCompleteParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersCompleteParameter, RemindersCompleteResponse>(p, CancellationToken.None);
        }
        public async Task<RemindersCompleteResponse> RemindersCompleteAsync(string reminder, CancellationToken cancellationToken)
        {
            var p = new RemindersCompleteParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersCompleteParameter, RemindersCompleteResponse>(p, cancellationToken);
        }
        public async Task<RemindersCompleteResponse> RemindersCompleteAsync(RemindersCompleteParameter parameter)
        {
            return await this.SendAsync<RemindersCompleteParameter, RemindersCompleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<RemindersCompleteResponse> RemindersCompleteAsync(RemindersCompleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersCompleteParameter, RemindersCompleteResponse>(parameter, cancellationToken);
        }
    }
}
