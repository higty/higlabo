
namespace HigLabo.Net.Slack
{
    public partial class AdminConversationsSearchParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.search";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Connected_Team_Ids { get; set; }
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public string Query { get; set; }
        public string Search_Channel_Types { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string Team_Ids { get; set; }
    }
    public partial class AdminConversationsSearchResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync()
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync(CancellationToken cancellationToken)
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter)
        {
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsSearchResponse> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsSearchParameter, AdminConversationsSearchResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(PagingContext<AdminConversationsSearchResponse> context)
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(CancellationToken cancellationToken, PagingContext<AdminConversationsSearchResponse> context)
        {
            var p = new AdminConversationsSearchParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter, PagingContext<AdminConversationsSearchResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminConversationsSearchResponse>> AdminConversationsSearchAsync(AdminConversationsSearchParameter parameter, PagingContext<AdminConversationsSearchResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
