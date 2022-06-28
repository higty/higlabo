
namespace HigLabo.Net.Slack
{
    public class StarsListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "stars.list";
        public string HttpMethod { get; private set; } = "GET";
        public int? Count { get; set; }
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
        public int? Page { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class StarsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<StarsListResponse> StarsListAsync()
        {
            var p = new StarsListParameter();
            return await this.SendAsync<StarsListParameter, StarsListResponse>(p, CancellationToken.None);
        }
        public async Task<StarsListResponse> StarsListAsync(CancellationToken cancellationToken)
        {
            var p = new StarsListParameter();
            return await this.SendAsync<StarsListParameter, StarsListResponse>(p, cancellationToken);
        }
        public async Task<StarsListResponse> StarsListAsync(StarsListParameter parameter)
        {
            return await this.SendAsync<StarsListParameter, StarsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<StarsListResponse> StarsListAsync(StarsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<StarsListParameter, StarsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<StarsListResponse>> StarsListAsync(PagingContext<StarsListResponse> context)
        {
            var p = new StarsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<StarsListResponse>> StarsListAsync(CancellationToken cancellationToken, PagingContext<StarsListResponse> context)
        {
            var p = new StarsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<StarsListResponse>> StarsListAsync(StarsListParameter parameter, PagingContext<StarsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<StarsListResponse>> StarsListAsync(StarsListParameter parameter, PagingContext<StarsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
