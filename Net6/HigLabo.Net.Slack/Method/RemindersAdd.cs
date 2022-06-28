
namespace HigLabo.Net.Slack
{
    public class RemindersAddParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "reminders.add";
        public string HttpMethod { get; private set; } = "POST";
        public string Text { get; set; } = "";
        public string Time { get; set; } = "";
        public Recurrence Recurrence { get; set; } = new Recurrence();
        public string Team_Id { get; set; } = "";
        public string User { get; set; } = "";
    }
    public partial class RemindersAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RemindersAddResponse> RemindersAddAsync(string text, string time)
        {
            var p = new RemindersAddParameter();
            p.Text = text;
            p.Time = time;
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(p, CancellationToken.None);
        }
        public async Task<RemindersAddResponse> RemindersAddAsync(string text, string time, CancellationToken cancellationToken)
        {
            var p = new RemindersAddParameter();
            p.Text = text;
            p.Time = time;
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(p, cancellationToken);
        }
        public async Task<RemindersAddResponse> RemindersAddAsync(RemindersAddParameter parameter)
        {
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<RemindersAddResponse> RemindersAddAsync(RemindersAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersAddParameter, RemindersAddResponse>(parameter, cancellationToken);
        }
    }
}
