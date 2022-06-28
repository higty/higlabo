
namespace HigLabo.Net.Slack
{
    public class RtmStartParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "rtm.start";
        public string HttpMethod { get; private set; } = "GET";
        public bool? Batch_Presence_Aware { get; set; }
        public bool? Include_Locale { get; set; }
        public bool? Mpim_Aware { get; set; }
        public bool? No_Latest { get; set; }
        public bool? No_Unreads { get; set; }
        public bool? Presence_Sub { get; set; }
        public bool? Simple_Latest { get; set; }
    }
    public partial class RtmStartResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<RtmStartResponse> RtmStartAsync()
        {
            var p = new RtmStartParameter();
            return await this.SendAsync<RtmStartParameter, RtmStartResponse>(p, CancellationToken.None);
        }
        public async Task<RtmStartResponse> RtmStartAsync(CancellationToken cancellationToken)
        {
            var p = new RtmStartParameter();
            return await this.SendAsync<RtmStartParameter, RtmStartResponse>(p, cancellationToken);
        }
        public async Task<RtmStartResponse> RtmStartAsync(RtmStartParameter parameter)
        {
            return await this.SendAsync<RtmStartParameter, RtmStartResponse>(parameter, CancellationToken.None);
        }
        public async Task<RtmStartResponse> RtmStartAsync(RtmStartParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RtmStartParameter, RtmStartResponse>(parameter, cancellationToken);
        }
    }
}
