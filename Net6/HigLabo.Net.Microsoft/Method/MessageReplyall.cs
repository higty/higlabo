using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageReplyallParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_Me_Messages_Id_ReplyAll,
            Users_IdOrUserPrincipalName_Messages_Id_ReplyAll,
            Me_MailFolders_Id_Messages_Id_ReplyAll,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_ReplyAll,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_Me_Messages_Id_ReplyAll: return $"/users/me/messages/{Id}/replyAll";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_ReplyAll: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/replyAll";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_ReplyAll: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/replyAll";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_ReplyAll: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/replyAll";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Comment { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string MailFoldersId { get; set; }
        public string MessagesId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
    }
    public partial class MessageReplyallResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyallResponse> MessageReplyallAsync()
        {
            var p = new MessageReplyallParameter();
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyallResponse> MessageReplyallAsync(CancellationToken cancellationToken)
        {
            var p = new MessageReplyallParameter();
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyallResponse> MessageReplyallAsync(MessageReplyallParameter parameter)
        {
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-replyall?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyallResponse> MessageReplyallAsync(MessageReplyallParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageReplyallParameter, MessageReplyallResponse>(parameter, cancellationToken);
        }
    }
}
