
namespace HigLabo.Net.Slack
{
    public partial class RtmConnectParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "rtm.connect";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool? Batch_Presence_Aware { get; set; }
        public bool? Presence_Sub { get; set; }
    }
    public partial class RtmConnectResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RtmConnectResponse> RtmConnectAsync()
        {
            var p = new RtmConnectParameter();
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(p, CancellationToken.None);
        }
        public async Task<RtmConnectResponse> RtmConnectAsync(CancellationToken cancellationToken)
        {
            var p = new RtmConnectParameter();
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(p, cancellationToken);
        }
        public async Task<RtmConnectResponse> RtmConnectAsync(RtmConnectParameter parameter)
        {
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(parameter, CancellationToken.None);
        }
        public async Task<RtmConnectResponse> RtmConnectAsync(RtmConnectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RtmConnectParameter, RtmConnectResponse>(parameter, cancellationToken);
        }
    }
}
