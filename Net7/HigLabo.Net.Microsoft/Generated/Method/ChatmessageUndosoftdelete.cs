using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-undosoftdelete?view=graph-rest-1.0
    /// </summary>
    public partial class ChatmessageUndosoftdeleteParameter : IRestApiParameter
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
                    case ApiPath.Teams_TeamsId_Channels_ChannelId_Messages_ChatMessageId_UndoSoftDelete: return $"/teams/{TeamsId}/channels/{ChannelId}/messages/{ChatMessageId}/undoSoftDelete";
                    case ApiPath.Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_UndoSoftDelete: return $"/teams/{TeamId}/channels/{ChannelId}/messages/{MessageId}/replies/{ReplyId}/undoSoftDelete";
                    case ApiPath.Users_UserId_Chats_ChatsId_Messages_ChatMessageId_UndoSoftDelete: return $"/users/{UserId}/chats/{ChatsId}/messages/{ChatMessageId}/undoSoftDelete";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamsId_Channels_ChannelId_Messages_ChatMessageId_UndoSoftDelete,
            Teams_TeamId_Channels_ChannelId_Messages_MessageId_Replies_ReplyId_UndoSoftDelete,
            Users_UserId_Chats_ChatsId_Messages_ChatMessageId_UndoSoftDelete,
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
    public partial class ChatmessageUndosoftdeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chatmessage-undosoftdelete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-undosoftdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageUndosoftdeleteResponse> ChatmessageUndosoftdeleteAsync()
        {
            var p = new ChatmessageUndosoftdeleteParameter();
            return await this.SendAsync<ChatmessageUndosoftdeleteParameter, ChatmessageUndosoftdeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-undosoftdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageUndosoftdeleteResponse> ChatmessageUndosoftdeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ChatmessageUndosoftdeleteParameter();
            return await this.SendAsync<ChatmessageUndosoftdeleteParameter, ChatmessageUndosoftdeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-undosoftdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageUndosoftdeleteResponse> ChatmessageUndosoftdeleteAsync(ChatmessageUndosoftdeleteParameter parameter)
        {
            return await this.SendAsync<ChatmessageUndosoftdeleteParameter, ChatmessageUndosoftdeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chatmessage-undosoftdelete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChatmessageUndosoftdeleteResponse> ChatmessageUndosoftdeleteAsync(ChatmessageUndosoftdeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatmessageUndosoftdeleteParameter, ChatmessageUndosoftdeleteResponse>(parameter, cancellationToken);
        }
    }
}
