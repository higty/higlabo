
namespace HigLabo.Net.Slack
{
    public class AdminBarriersListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.barriers.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
    }
    public partial class AdminBarriersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminBarriersListResponse> AdminBarriersListAsync()
        {
            var p = new AdminBarriersListParameter();
            return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminBarriersListResponse> AdminBarriersListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminBarriersListParameter();
            return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(p, cancellationToken);
        }
        public async Task<AdminBarriersListResponse> AdminBarriersListAsync(AdminBarriersListParameter parameter)
        {
            return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminBarriersListResponse> AdminBarriersListAsync(AdminBarriersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminBarriersListParameter, AdminBarriersListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminBarriersListResponse>> AdminBarriersListAsync(PagingContext<AdminBarriersListResponse> context)
        {
            var p = new AdminBarriersListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminBarriersListResponse>> AdminBarriersListAsync(CancellationToken cancellationToken, PagingContext<AdminBarriersListResponse> context)
        {
            var p = new AdminBarriersListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminBarriersListResponse>> AdminBarriersListAsync(AdminBarriersListParameter parameter, PagingContext<AdminBarriersListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminBarriersListResponse>> AdminBarriersListAsync(AdminBarriersListParameter parameter, PagingContext<AdminBarriersListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
