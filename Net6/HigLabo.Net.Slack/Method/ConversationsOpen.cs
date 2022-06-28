
namespace HigLabo.Net.Slack
{
    public class ConversationsOpenParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.open";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public bool? Prevent_Creation { get; set; }
        public bool? Return_Im { get; set; }
        public string Users { get; set; } = "";
    }
    public partial class ConversationsOpenResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsOpenResponse> ConversationsOpenAsync()
        {
            var p = new ConversationsOpenParameter();
            return await this.SendAsync<ConversationsOpenParameter, ConversationsOpenResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsOpenResponse> ConversationsOpenAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationsOpenParameter();
            return await this.SendAsync<ConversationsOpenParameter, ConversationsOpenResponse>(p, cancellationToken);
        }
        public async Task<ConversationsOpenResponse> ConversationsOpenAsync(ConversationsOpenParameter parameter)
        {
            return await this.SendAsync<ConversationsOpenParameter, ConversationsOpenResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsOpenResponse> ConversationsOpenAsync(ConversationsOpenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsOpenParameter, ConversationsOpenResponse>(parameter, cancellationToken);
        }
    }
}
