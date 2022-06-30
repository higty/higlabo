
namespace HigLabo.Net.Slack
{
    public partial class ConversationsCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.create";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Name { get; set; }
        public bool? Is_Private { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class ConversationsCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsCreateResponse> ConversationsCreateAsync(string name)
        {
            var p = new ConversationsCreateParameter();
            p.Name = name;
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsCreateResponse> ConversationsCreateAsync(string name, CancellationToken cancellationToken)
        {
            var p = new ConversationsCreateParameter();
            p.Name = name;
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(p, cancellationToken);
        }
        public async Task<ConversationsCreateResponse> ConversationsCreateAsync(ConversationsCreateParameter parameter)
        {
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsCreateResponse> ConversationsCreateAsync(ConversationsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsCreateParameter, ConversationsCreateResponse>(parameter, cancellationToken);
        }
    }
}
