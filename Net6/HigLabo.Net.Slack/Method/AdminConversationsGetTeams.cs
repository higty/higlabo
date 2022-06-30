
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsGetTeamsParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.getTeams";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel_Id { get; set; }
        public string Cursor { get; set; }
        public int? Limit { get; set; }
    }
    public partial class AdminConversationsGetTeamsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsGetTeamsResponse> AdminConversationsGetTeamsAsync(string channel_Id)
        {
            var p = new AdminConversationsGetTeamsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetTeamsParameter, AdminConversationsGetTeamsResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsGetTeamsResponse> AdminConversationsGetTeamsAsync(string channel_Id, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsGetTeamsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendAsync<AdminConversationsGetTeamsParameter, AdminConversationsGetTeamsResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsGetTeamsResponse> AdminConversationsGetTeamsAsync(AdminConversationsGetTeamsParameter parameter)
        {
            return await this.SendAsync<AdminConversationsGetTeamsParameter, AdminConversationsGetTeamsResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsGetTeamsResponse> AdminConversationsGetTeamsAsync(AdminConversationsGetTeamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsGetTeamsParameter, AdminConversationsGetTeamsResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminConversationsGetTeamsResponse>> AdminConversationsGetTeamsAsync(string channel_Id, PagingContext<AdminConversationsGetTeamsResponse> context)
        {
            var p = new AdminConversationsGetTeamsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminConversationsGetTeamsResponse>> AdminConversationsGetTeamsAsync(string channel_Id, PagingContext<AdminConversationsGetTeamsResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsGetTeamsParameter();
            p.Channel_Id = channel_Id;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminConversationsGetTeamsResponse>> AdminConversationsGetTeamsAsync(AdminConversationsGetTeamsParameter parameter, PagingContext<AdminConversationsGetTeamsResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminConversationsGetTeamsResponse>> AdminConversationsGetTeamsAsync(AdminConversationsGetTeamsParameter parameter, PagingContext<AdminConversationsGetTeamsResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
