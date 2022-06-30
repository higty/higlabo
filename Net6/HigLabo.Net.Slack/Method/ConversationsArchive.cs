
namespace HigLabo.Net.Slack
{
    public partial class ConversationsArchiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.archive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
    }
    public partial class ConversationsArchiveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsArchiveResponse> ConversationsArchiveAsync(string channel)
        {
            var p = new ConversationsArchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsArchiveResponse> ConversationsArchiveAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsArchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(p, cancellationToken);
        }
        public async Task<ConversationsArchiveResponse> ConversationsArchiveAsync(ConversationsArchiveParameter parameter)
        {
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsArchiveResponse> ConversationsArchiveAsync(ConversationsArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(parameter, cancellationToken);
        }
    }
}
