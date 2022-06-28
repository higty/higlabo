
namespace HigLabo.Net.Slack
{
    public class UsersListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "users.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Cursor { get; set; } = "";
        public bool? Include_Locale { get; set; }
        public double? Limit { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class UsersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<UsersListResponse> UsersListAsync()
        {
            var p = new UsersListParameter();
            return await this.SendAsync<UsersListParameter, UsersListResponse>(p, CancellationToken.None);
        }
        public async Task<UsersListResponse> UsersListAsync(CancellationToken cancellationToken)
        {
            var p = new UsersListParameter();
            return await this.SendAsync<UsersListParameter, UsersListResponse>(p, cancellationToken);
        }
        public async Task<UsersListResponse> UsersListAsync(UsersListParameter parameter)
        {
            return await this.SendAsync<UsersListParameter, UsersListResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersListResponse> UsersListAsync(UsersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersListParameter, UsersListResponse>(parameter, cancellationToken);
        }
        public async Task<List<UsersListResponse>> UsersListAsync(PagingContext<UsersListResponse> context)
        {
            var p = new UsersListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<UsersListResponse>> UsersListAsync(CancellationToken cancellationToken, PagingContext<UsersListResponse> context)
        {
            var p = new UsersListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<UsersListResponse>> UsersListAsync(UsersListParameter parameter, PagingContext<UsersListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<UsersListResponse>> UsersListAsync(UsersListParameter parameter, PagingContext<UsersListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
