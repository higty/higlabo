
namespace HigLabo.Net.Slack
{
    public partial class PinsAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "pins.add";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Timestamp { get; set; }
    }
    public partial class PinsAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/pins.add
        /// </summary>
        public async Task<PinsAddResponse> PinsAddAsync(string channel)
        {
            var p = new PinsAddParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.add
        /// </summary>
        public async Task<PinsAddResponse> PinsAddAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new PinsAddParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.add
        /// </summary>
        public async Task<PinsAddResponse> PinsAddAsync(PinsAddParameter parameter)
        {
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/pins.add
        /// </summary>
        public async Task<PinsAddResponse> PinsAddAsync(PinsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(parameter, cancellationToken);
        }
    }
}
