
namespace HigLabo.Net.Slack
{
    public partial class AuthTeamsListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "auth.teams.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Cursor { get; set; }
        public bool? Include_Icon { get; set; }
        public int? Limit { get; set; }
    }
    public partial class AuthTeamsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AuthTeamsListResponse> AuthTeamsListAsync()
        {
            var p = new AuthTeamsListParameter();
            return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(p, CancellationToken.None);
        }
        public async Task<AuthTeamsListResponse> AuthTeamsListAsync(CancellationToken cancellationToken)
        {
            var p = new AuthTeamsListParameter();
            return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(p, cancellationToken);
        }
        public async Task<AuthTeamsListResponse> AuthTeamsListAsync(AuthTeamsListParameter parameter)
        {
            return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AuthTeamsListResponse> AuthTeamsListAsync(AuthTeamsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthTeamsListParameter, AuthTeamsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AuthTeamsListResponse>> AuthTeamsListAsync(PagingContext<AuthTeamsListResponse> context)
        {
            var p = new AuthTeamsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AuthTeamsListResponse>> AuthTeamsListAsync(CancellationToken cancellationToken, PagingContext<AuthTeamsListResponse> context)
        {
            var p = new AuthTeamsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AuthTeamsListResponse>> AuthTeamsListAsync(AuthTeamsListParameter parameter, PagingContext<AuthTeamsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AuthTeamsListResponse>> AuthTeamsListAsync(AuthTeamsListParameter parameter, PagingContext<AuthTeamsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
