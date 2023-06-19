using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class BotsInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "bots.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Bot { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class BotsInfoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/bots.info
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/bots.info
        /// </summary>
        public async ValueTask<BotsInfoResponse> BotsInfoAsync()
        {
            var p = new BotsInfoParameter();
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/bots.info
        /// </summary>
        public async ValueTask<BotsInfoResponse> BotsInfoAsync(CancellationToken cancellationToken)
        {
            var p = new BotsInfoParameter();
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/bots.info
        /// </summary>
        public async ValueTask<BotsInfoResponse> BotsInfoAsync(BotsInfoParameter parameter)
        {
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/bots.info
        /// </summary>
        public async ValueTask<BotsInfoResponse> BotsInfoAsync(BotsInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BotsInfoParameter, BotsInfoResponse>(parameter, cancellationToken);
        }
    }
}
