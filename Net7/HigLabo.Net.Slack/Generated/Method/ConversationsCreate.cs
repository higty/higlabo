using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.create
    /// </summary>
    public partial class ConversationsCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.create";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Name { get; set; }
        public bool? Is_Private { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class ConversationsCreateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.create
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.create
        /// </summary>
        public async ValueTask<ConversationsCreateResponse> ConversationsCreateAsync(string? name)
        {
            var p = new ConversationsCreateParameter();
            p.Name = name;
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.create
        /// </summary>
        public async ValueTask<ConversationsCreateResponse> ConversationsCreateAsync(string? name, CancellationToken cancellationToken)
        {
            var p = new ConversationsCreateParameter();
            p.Name = name;
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.create
        /// </summary>
        public async ValueTask<ConversationsCreateResponse> ConversationsCreateAsync(ConversationsCreateParameter parameter)
        {
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.create
        /// </summary>
        public async ValueTask<ConversationsCreateResponse> ConversationsCreateAsync(ConversationsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(parameter, cancellationToken);
        }
    }
}
