
namespace HigLabo.Net.Slack
{
    public class RemindersDeleteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "reminders.delete";
        public string HttpMethod { get; private set; } = "POST";
        public string Reminder { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class RemindersDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RemindersDeleteResponse> RemindersDeleteAsync(string reminder)
        {
            var p = new RemindersDeleteParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<RemindersDeleteResponse> RemindersDeleteAsync(string reminder, CancellationToken cancellationToken)
        {
            var p = new RemindersDeleteParameter();
            p.Reminder = reminder;
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(p, cancellationToken);
        }
        public async Task<RemindersDeleteResponse> RemindersDeleteAsync(RemindersDeleteParameter parameter)
        {
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<RemindersDeleteResponse> RemindersDeleteAsync(RemindersDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersDeleteParameter, RemindersDeleteResponse>(parameter, cancellationToken);
        }
    }
}
