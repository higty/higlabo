
namespace HigLabo.Net.Slack
{
    public class AdminTeamsListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.teams.list";
        public string HttpMethod { get; private set; } = "POST";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
    }
    public partial class AdminTeamsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync()
        {
            var p = new AdminTeamsListParameter();
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminTeamsListParameter();
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync(AdminTeamsListParameter parameter)
        {
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync(AdminTeamsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(PagingContext<AdminTeamsListResponse> context)
        {
            var p = new AdminTeamsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(CancellationToken cancellationToken, PagingContext<AdminTeamsListResponse> context)
        {
            var p = new AdminTeamsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(AdminTeamsListParameter parameter, PagingContext<AdminTeamsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(AdminTeamsListParameter parameter, PagingContext<AdminTeamsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
