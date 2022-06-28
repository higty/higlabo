
namespace HigLabo.Net.Slack
{
    public class ConversationsSetPurposeParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "conversations.setPurpose";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel { get; set; } = "";
        public string Purpose { get; set; } = "";
    }
    public partial class ConversationsSetPurposeResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsSetPurposeResponse> ConversationsSetPurposeAsync(string channel, string purpose)
        {
            var p = new ConversationsSetPurposeParameter();
            p.Channel = channel;
            p.Purpose = purpose;
            return await this.SendAsync<ConversationsSetPurposeParameter, ConversationsSetPurposeResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsSetPurposeResponse> ConversationsSetPurposeAsync(string channel, string purpose, CancellationToken cancellationToken)
        {
            var p = new ConversationsSetPurposeParameter();
            p.Channel = channel;
            p.Purpose = purpose;
            return await this.SendAsync<ConversationsSetPurposeParameter, ConversationsSetPurposeResponse>(p, cancellationToken);
        }
        public async Task<ConversationsSetPurposeResponse> ConversationsSetPurposeAsync(ConversationsSetPurposeParameter parameter)
        {
            return await this.SendAsync<ConversationsSetPurposeParameter, ConversationsSetPurposeResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsSetPurposeResponse> ConversationsSetPurposeAsync(ConversationsSetPurposeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsSetPurposeParameter, ConversationsSetPurposeResponse>(parameter, cancellationToken);
        }
    }
}
