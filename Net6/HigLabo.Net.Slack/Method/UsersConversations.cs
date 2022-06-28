
namespace HigLabo.Net.Slack
{
    public class UsersConversationsParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "users.conversations";
        public string HttpMethod { get; private set; } = "GET";
        public string Cursor { get; set; } = "";
        public bool? Exclude_Archived { get; set; }
        public double? Limit { get; set; }
        public string Team_Id { get; set; } = "";
        public string Types { get; set; } = "";
        public string User { get; set; } = "";
    }
    public partial class UsersConversationsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersConversationsResponse> UsersConversationsAsync()
        {
            var p = new UsersConversationsParameter();
            return await this.SendAsync<UsersConversationsParameter, UsersConversationsResponse>(p, CancellationToken.None);
        }
        public async Task<UsersConversationsResponse> UsersConversationsAsync(CancellationToken cancellationToken)
        {
            var p = new UsersConversationsParameter();
            return await this.SendAsync<UsersConversationsParameter, UsersConversationsResponse>(p, cancellationToken);
        }
        public async Task<UsersConversationsResponse> UsersConversationsAsync(UsersConversationsParameter parameter)
        {
            return await this.SendAsync<UsersConversationsParameter, UsersConversationsResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersConversationsResponse> UsersConversationsAsync(UsersConversationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersConversationsParameter, UsersConversationsResponse>(parameter, cancellationToken);
        }
        public async Task<List<UsersConversationsResponse>> UsersConversationsAsync(PagingContext<UsersConversationsResponse> context)
        {
            var p = new UsersConversationsParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<UsersConversationsResponse>> UsersConversationsAsync(CancellationToken cancellationToken, PagingContext<UsersConversationsResponse> context)
        {
            var p = new UsersConversationsParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<UsersConversationsResponse>> UsersConversationsAsync(UsersConversationsParameter parameter, PagingContext<UsersConversationsResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<UsersConversationsResponse>> UsersConversationsAsync(UsersConversationsParameter parameter, PagingContext<UsersConversationsResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
