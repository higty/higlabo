
namespace HigLabo.Net.Slack
{
    public class ConversationsUnarchiveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.unarchive";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
    }
    public partial class ConversationsUnarchiveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(string channel)
        {
            var p = new ConversationsUnarchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsUnarchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(p, cancellationToken);
        }
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(ConversationsUnarchiveParameter parameter)
        {
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(ConversationsUnarchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(parameter, cancellationToken);
        }
    }
}
