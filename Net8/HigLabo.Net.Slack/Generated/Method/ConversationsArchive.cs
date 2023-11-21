using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsArchiveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.archive";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
    }
    public partial class ConversationsArchiveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.archive
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.archive
        /// </summary>
        public async ValueTask<ConversationsArchiveResponse> ConversationsArchiveAsync(string? channel)
        {
            var p = new ConversationsArchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.archive
        /// </summary>
        public async ValueTask<ConversationsArchiveResponse> ConversationsArchiveAsync(string? channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsArchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.archive
        /// </summary>
        public async ValueTask<ConversationsArchiveResponse> ConversationsArchiveAsync(ConversationsArchiveParameter parameter)
        {
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.archive
        /// </summary>
        public async ValueTask<ConversationsArchiveResponse> ConversationsArchiveAsync(ConversationsArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsArchiveParameter, ConversationsArchiveResponse>(parameter, cancellationToken);
        }
    }
}
