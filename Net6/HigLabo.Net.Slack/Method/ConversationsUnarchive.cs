using HigLabo.Net.OAuth;

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
        /// <summary>
        /// https://api.slack.com/methods/conversations.unarchive
        /// </summary>
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(string channel)
        {
            var p = new ConversationsUnarchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.unarchive
        /// </summary>
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsUnarchiveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.unarchive
        /// </summary>
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(ConversationsUnarchiveParameter parameter)
        {
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.unarchive
        /// </summary>
        public async Task<ConversationsUnarchiveResponse> ConversationsUnarchiveAsync(ConversationsUnarchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsUnarchiveParameter, ConversationsUnarchiveResponse>(parameter, cancellationToken);
        }
    }
}
