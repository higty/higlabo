using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/pins.list
    /// </summary>
    public partial class PinsListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "pins.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel { get; set; }
    }
    public partial class PinsListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/pins.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/pins.list
        /// </summary>
        public async ValueTask<PinsListResponse> PinsListAsync(string? channel)
        {
            var p = new PinsListParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsListParameter, PinsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.list
        /// </summary>
        public async ValueTask<PinsListResponse> PinsListAsync(string? channel, CancellationToken cancellationToken)
        {
            var p = new PinsListParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsListParameter, PinsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.list
        /// </summary>
        public async ValueTask<PinsListResponse> PinsListAsync(PinsListParameter parameter)
        {
            return await this.SendAsync<PinsListParameter, PinsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.list
        /// </summary>
        public async ValueTask<PinsListResponse> PinsListAsync(PinsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PinsListParameter, PinsListResponse>(parameter, cancellationToken);
        }
    }
}
