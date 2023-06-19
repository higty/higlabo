using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
    /// </summary>
    public partial class MessageReplyallParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? MailFoldersId { get; set; }
            public string? MessagesId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_Me_Messages_Id_ReplyAll: return $"/users/me/messages/{Id}/replyAll";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_ReplyAll: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/replyAll";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_ReplyAll: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/replyAll";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_ReplyAll: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/replyAll";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_Me_Messages_Id_ReplyAll,
            Users_IdOrUserPrincipalName_Messages_Id_ReplyAll,
            Me_MailFolders_Id_Messages_Id_ReplyAll,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_ReplyAll,
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
        public string? Comment { get; set; }
    }
    public partial class MessageReplyallResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageReplyallResponse> MessageReplyallAsync()
        {
            var p = new MessageReplyallParameter();
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageReplyallResponse> MessageReplyallAsync(CancellationToken cancellationToken)
        {
            var p = new MessageReplyallParameter();
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageReplyallResponse> MessageReplyallAsync(MessageReplyallParameter parameter)
        {
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageReplyallResponse> MessageReplyallAsync(MessageReplyallParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(parameter, cancellationToken);
        }
    }
}
