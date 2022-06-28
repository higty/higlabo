
namespace HigLabo.Net.Slack
{
    public class AdminEmojiListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.emoji.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
    }
    public partial class AdminEmojiListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminEmojiListResponse> AdminEmojiListAsync()
        {
            var p = new AdminEmojiListParameter();
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminEmojiListResponse> AdminEmojiListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminEmojiListParameter();
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(p, cancellationToken);
        }
        public async Task<AdminEmojiListResponse> AdminEmojiListAsync(AdminEmojiListParameter parameter)
        {
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminEmojiListResponse> AdminEmojiListAsync(AdminEmojiListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminEmojiListParameter, AdminEmojiListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminEmojiListResponse>> AdminEmojiListAsync(PagingContext<AdminEmojiListResponse> context)
        {
            var p = new AdminEmojiListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminEmojiListResponse>> AdminEmojiListAsync(CancellationToken cancellationToken, PagingContext<AdminEmojiListResponse> context)
        {
            var p = new AdminEmojiListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminEmojiListResponse>> AdminEmojiListAsync(AdminEmojiListParameter parameter, PagingContext<AdminEmojiListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminEmojiListResponse>> AdminEmojiListAsync(AdminEmojiListParameter parameter, PagingContext<AdminEmojiListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
