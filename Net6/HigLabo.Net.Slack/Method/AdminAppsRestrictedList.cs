
namespace HigLabo.Net.Slack
{
    public class AdminAppsRestrictedListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.apps.restricted.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Cursor { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public int? Limit { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminAppsRestrictedListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync()
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter)
        {
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(PagingContext<AdminAppsRestrictedListResponse> context)
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsRestrictedListResponse> context)
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter, PagingContext<AdminAppsRestrictedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter, PagingContext<AdminAppsRestrictedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
