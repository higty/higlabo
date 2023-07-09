using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class PinsRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "pins.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
        public string? Timestamp { get; set; }
    }
    public partial class PinsRemoveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/pins.remove
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/pins.remove
        /// </summary>
        public async ValueTask<PinsRemoveResponse> PinsRemoveAsync(string? channel)
        {
            var p = new PinsRemoveParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.remove
        /// </summary>
        public async ValueTask<PinsRemoveResponse> PinsRemoveAsync(string? channel, CancellationToken cancellationToken)
        {
            var p = new PinsRemoveParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.remove
        /// </summary>
        public async ValueTask<PinsRemoveResponse> PinsRemoveAsync(PinsRemoveParameter parameter)
        {
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.remove
        /// </summary>
        public async ValueTask<PinsRemoveResponse> PinsRemoveAsync(PinsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
