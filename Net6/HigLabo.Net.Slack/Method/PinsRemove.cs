
namespace HigLabo.Net.Slack
{
    public partial class PinsRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "pins.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Timestamp { get; set; }
    }
    public partial class PinsRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<PinsRemoveResponse> PinsRemoveAsync(string channel)
        {
            var p = new PinsRemoveParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<PinsRemoveResponse> PinsRemoveAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new PinsRemoveParameter();
            p.Channel = channel;
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(p, cancellationToken);
        }
        public async Task<PinsRemoveResponse> PinsRemoveAsync(PinsRemoveParameter parameter)
        {
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<PinsRemoveResponse> PinsRemoveAsync(PinsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PinsRemoveParameter, PinsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
