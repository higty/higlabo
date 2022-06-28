
namespace HigLabo.Net.Slack
{
    public class AdminConversationsEkmListOriginalConnectedChannelInfoParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.conversations.ekm.listOriginalConnectedChannelInfo";
        public string HttpMethod { get; private set; } = "GET";
        public string Channel_Ids { get; set; } = "";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
        public string Team_Ids { get; set; } = "";
    }
    public partial class AdminConversationsEkmListOriginalConnectedChannelInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync()
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(p, CancellationToken.None);
        }
        public async Task<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(CancellationToken cancellationToken)
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(p, cancellationToken);
        }
        public async Task<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter)
        {
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsEkmListOriginalConnectedChannelInfoParameter, AdminConversationsEkmListOriginalConnectedChannelInfoResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context)
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(CancellationToken cancellationToken, PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context)
        {
            var p = new AdminConversationsEkmListOriginalConnectedChannelInfoParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter, PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminConversationsEkmListOriginalConnectedChannelInfoResponse>> AdminConversationsEkmListOriginalConnectedChannelInfoAsync(AdminConversationsEkmListOriginalConnectedChannelInfoParameter parameter, PagingContext<AdminConversationsEkmListOriginalConnectedChannelInfoResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
