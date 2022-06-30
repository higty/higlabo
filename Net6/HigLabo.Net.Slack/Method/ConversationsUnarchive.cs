
namespace HigLabo.Net.Slack
{
    public partial class ConversationsUnarchiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.unarchive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
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
