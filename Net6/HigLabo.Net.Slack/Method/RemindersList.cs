
namespace HigLabo.Net.Slack
{
    public partial class RemindersListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reminders.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Team_Id { get; set; }
    }
    public partial class RemindersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RemindersListResponse> RemindersListAsync()
        {
            var p = new RemindersListParameter();
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(p, CancellationToken.None);
        }
        public async Task<RemindersListResponse> RemindersListAsync(CancellationToken cancellationToken)
        {
            var p = new RemindersListParameter();
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(p, cancellationToken);
        }
        public async Task<RemindersListResponse> RemindersListAsync(RemindersListParameter parameter)
        {
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(parameter, CancellationToken.None);
        }
        public async Task<RemindersListResponse> RemindersListAsync(RemindersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RemindersListParameter, RemindersListResponse>(parameter, cancellationToken);
        }
    }
}
