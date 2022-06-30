
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public string Team_Id { get; set; }
        public string User_Id { get; set; }
    }
    public partial class AdminUsersSessionListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSessionListResponse> AdminUsersSessionListAsync()
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSessionListResponse> AdminUsersSessionListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSessionListResponse> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSessionListResponse> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(PagingContext<AdminUsersSessionListResponse> context)
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(CancellationToken cancellationToken, PagingContext<AdminUsersSessionListResponse> context)
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter, PagingContext<AdminUsersSessionListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter, PagingContext<AdminUsersSessionListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
