
namespace HigLabo.Net.Slack
{
    public class PinsAddParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "pins.add";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string Timestamp { get; set; } = "";
    }
    public partial class PinsAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<PinsAddResponse> PinsAddAsync(string channel)
        {
            var p = new PinsAddParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(p, CancellationToken.None);
        }
        public async Task<PinsAddResponse> PinsAddAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new PinsAddParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(p, cancellationToken);
        }
        public async Task<PinsAddResponse> PinsAddAsync(PinsAddParameter parameter)
        {
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<PinsAddResponse> PinsAddAsync(PinsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PinsAddParameter, PinsAddResponse>(parameter, cancellationToken);
        }
    }
}
