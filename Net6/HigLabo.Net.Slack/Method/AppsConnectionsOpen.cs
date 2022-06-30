
namespace HigLabo.Net.Slack
{
    public partial class AppsConnectionsOpenParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.connections.open";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AppsConnectionsOpenResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync()
        {
            var p = new AppsConnectionsOpenParameter();
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(p, CancellationToken.None);
        }
        public async Task<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync(CancellationToken cancellationToken)
        {
            var p = new AppsConnectionsOpenParameter();
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(p, cancellationToken);
        }
        public async Task<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync(AppsConnectionsOpenParameter parameter)
        {
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync(AppsConnectionsOpenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(parameter, cancellationToken);
        }
    }
}
