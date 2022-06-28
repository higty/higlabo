
namespace HigLabo.Net.Slack
{
    public class AdminAppsApprovedListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.apps.approved.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Cursor { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public int? Limit { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminAppsApprovedListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync()
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter)
        {
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(PagingContext<AdminAppsApprovedListResponse> context)
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsApprovedListResponse> context)
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter, PagingContext<AdminAppsApprovedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter, PagingContext<AdminAppsApprovedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
