
namespace HigLabo.Net.Slack
{
    public class ReactionsAddParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "reactions.add";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string Name { get; set; } = "";
        public string Timestamp { get; set; } = "";
    }
    public partial class ReactionsAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ReactionsAddResponse> ReactionsAddAsync(string channel, string name, string timestamp)
        {
            var p = new ReactionsAddParameter();
            p.Channel = channel;
            p.Name = name;
            p.Timestamp = timestamp;
            return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(p, CancellationToken.None);
        }
        public async Task<ReactionsAddResponse> ReactionsAddAsync(string channel, string name, string timestamp, CancellationToken cancellationToken)
        {
            var p = new ReactionsAddParameter();
            p.Channel = channel;
            p.Name = name;
            p.Timestamp = timestamp;
            return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(p, cancellationToken);
        }
        public async Task<ReactionsAddResponse> ReactionsAddAsync(ReactionsAddParameter parameter)
        {
            return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<ReactionsAddResponse> ReactionsAddAsync(ReactionsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReactionsAddParameter, ReactionsAddResponse>(parameter, cancellationToken);
        }
    }
}
