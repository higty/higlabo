using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class RtmConnectParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "rtm.connect";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool Batch_Presence_Aware { get; set; }
        public bool Presence_Sub { get; set; }
    }
    public partial class RtmConnectResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/rtm.connect
        /// </summary>
        public async Task<RtmConnectResponse> RtmConnectAsync()
        {
            var p = new RtmConnectParameter();
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/rtm.connect
        /// </summary>
        public async Task<RtmConnectResponse> RtmConnectAsync(CancellationToken cancellationToken)
        {
            var p = new RtmConnectParameter();
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/rtm.connect
        /// </summary>
        public async Task<RtmConnectResponse> RtmConnectAsync(RtmConnectParameter parameter)
        {
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/rtm.connect
        /// </summary>
        public async Task<RtmConnectResponse> RtmConnectAsync(RtmConnectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(parameter, cancellationToken);
        }
    }
}
