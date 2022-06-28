
namespace HigLabo.Net.Slack
{
    public class ConversationsListConnectInvitesParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "conversations.listConnectInvites";
        public string HttpMethod { get; private set; } = "POST";
        public int? Count { get; set; }
        public string Cursor { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class ConversationsListConnectInvitesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync()
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(p, cancellationToken);
        }
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter)
        {
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsListConnectInvitesResponse> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsListConnectInvitesParameter, ConversationsListConnectInvitesResponse>(parameter, cancellationToken);
        }
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(PagingContext<ConversationsListConnectInvitesResponse> context)
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(CancellationToken cancellationToken, PagingContext<ConversationsListConnectInvitesResponse> context)
        {
            var p = new ConversationsListConnectInvitesParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter, PagingContext<ConversationsListConnectInvitesResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ConversationsListConnectInvitesResponse>> ConversationsListConnectInvitesAsync(ConversationsListConnectInvitesParameter parameter, PagingContext<ConversationsListConnectInvitesResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
