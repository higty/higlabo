
namespace HigLabo.Net.Slack
{
    public class AppsEventAuthorizationsListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "apps.event.authorizations.list";
        public string HttpMethod { get; private set; } = "POST";
        public string Event_Context { get; set; } = "";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
    }
    public partial class AppsEventAuthorizationsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(string event_Context)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(p, CancellationToken.None);
        }
        public async Task<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(string event_Context, CancellationToken cancellationToken)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(p, cancellationToken);
        }
        public async Task<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter)
        {
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(string event_Context, PagingContext<AppsEventAuthorizationsListResponse> context)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(string event_Context, PagingContext<AppsEventAuthorizationsListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter, PagingContext<AppsEventAuthorizationsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter, PagingContext<AppsEventAuthorizationsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
