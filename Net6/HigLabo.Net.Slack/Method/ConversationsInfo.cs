
namespace HigLabo.Net.Slack
{
    public class ConversationsInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.info";
        public string HttpMethod { get; private set; } = "GET";
        public string Channel { get; set; } = "";
        public bool? Include_Locale { get; set; }
        public bool? Include_Num_Members { get; set; }
    }
    public partial class ConversationsInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsInfoResponse> ConversationsInfoAsync(string channel)
        {
            var p = new ConversationsInfoParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsInfoResponse> ConversationsInfoAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsInfoParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(p, cancellationToken);
        }
        public async Task<ConversationsInfoResponse> ConversationsInfoAsync(ConversationsInfoParameter parameter)
        {
            return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsInfoResponse> ConversationsInfoAsync(ConversationsInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsInfoParameter, ConversationsInfoResponse>(parameter, cancellationToken);
        }
    }
}
