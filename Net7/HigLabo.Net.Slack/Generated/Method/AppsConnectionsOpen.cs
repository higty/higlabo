using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.connections.open
    /// </summary>
    public partial class AppsConnectionsOpenParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.connections.open";
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AppsConnectionsOpenResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.connections.open
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.connections.open
        /// </summary>
        public async ValueTask<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync()
        {
            var p = new AppsConnectionsOpenParameter();
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.connections.open
        /// </summary>
        public async ValueTask<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync(CancellationToken cancellationToken)
        {
            var p = new AppsConnectionsOpenParameter();
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.connections.open
        /// </summary>
        public async ValueTask<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync(AppsConnectionsOpenParameter parameter)
        {
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.connections.open
        /// </summary>
        public async ValueTask<AppsConnectionsOpenResponse> AppsConnectionsOpenAsync(AppsConnectionsOpenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsConnectionsOpenParameter, AppsConnectionsOpenResponse>(parameter, cancellationToken);
        }
    }
}
