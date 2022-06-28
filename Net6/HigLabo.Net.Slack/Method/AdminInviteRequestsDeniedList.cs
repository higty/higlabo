
namespace HigLabo.Net.Slack
{
    public class AdminInviteRequestsDeniedListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.inviteRequests.denied.list";
        public string HttpMethod { get; private set; } = "POST";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminInviteRequestsDeniedListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync()
        {
            var p = new AdminInviteRequestsDeniedListParameter();
            return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsDeniedListParameter();
            return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(p, cancellationToken);
        }
        public async Task<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsDeniedListResponse> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsDeniedListParameter, AdminInviteRequestsDeniedListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(PagingContext<AdminInviteRequestsDeniedListResponse> context)
        {
            var p = new AdminInviteRequestsDeniedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(CancellationToken cancellationToken, PagingContext<AdminInviteRequestsDeniedListResponse> context)
        {
            var p = new AdminInviteRequestsDeniedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter, PagingContext<AdminInviteRequestsDeniedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminInviteRequestsDeniedListResponse>> AdminInviteRequestsDeniedListAsync(AdminInviteRequestsDeniedListParameter parameter, PagingContext<AdminInviteRequestsDeniedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
