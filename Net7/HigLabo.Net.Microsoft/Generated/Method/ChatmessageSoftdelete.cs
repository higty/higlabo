using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-softdelete?view=graph-rest-1.0
    /// </summary>
    public partial class ChatmessageSoftdeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamsId { get; set; }
            public string? ChannelId { get; set; }
            public string? ChatMessageId { get; set; }
            public string? TeamId { get; set; }
            public string? MessageId { get; set; }
            public string? ReplyId { get; set; }
            public string? UserId { get; set; }
            public string? ChatsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamsId_Channels_ChannelId_Messages_ChatMessageId_SoftDelete: return $"/teams/{TeamsId}/channels/{ChannelId}/messages/{ChatMessageId}/softDelete";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_SoftDelete: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}/softDelete";
                    case ApiPath.Users_UserId_Chats_ChatsId_Messages_ChatMessageId_SoftDelete: return $"/users/{UserId}/chats/{ChatsId}/messages/{ChatMessageId}/softDelete";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamsId_Channels_ChannelId_Messages_ChatMessageId_SoftDelete,
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_SoftDelete,
            Users_UserId_Chats_ChatsId_Messages_ChatMessageId_SoftDelete,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ChatmessageSoftdeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-softdelete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-softdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageSoftdeleteResponse> ChatmessageSoftdeleteAsync()
        {
            var p = new ChatmessageSoftdeleteParameter();
            return await this.SendAsync<ChatmessageSoftdeleteParameter, ChatmessageSoftdeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-softdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageSoftdeleteResponse> ChatmessageSoftdeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageSoftdeleteParameter();
            return await this.SendAsync<ChatmessageSoftdeleteParameter, ChatmessageSoftdeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-softdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageSoftdeleteResponse> ChatmessageSoftdeleteAsync(ChatmessageSoftdeleteParameter parameter)
        {
            return await this.SendAsync<ChatmessageSoftdeleteParameter, ChatmessageSoftdeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-softdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageSoftdeleteResponse> ChatmessageSoftdeleteAsync(ChatmessageSoftdeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageSoftdeleteParameter, ChatmessageSoftdeleteResponse>(parameter, cancellationToken);
        }
    }
}
