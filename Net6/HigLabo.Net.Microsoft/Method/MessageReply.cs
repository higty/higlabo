using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-reply?view=graph-rest-1.0
    /// </summary>
    public partial class MessageReplyParameter : IRestApiParameter
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
                    case ApiPath.Me_Messages_Id_Reply: return $"/me/messages/{Id}/reply";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Reply: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/reply";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_Reply: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/reply";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Reply: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/reply";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Messages_Id_Reply,
            Users_IdOrUserPrincipalName_Messages_Id_Reply,
            Me_MailFolders_Id_Messages_Id_Reply,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Reply,
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
        public Message? Message { get; set; }
    }
    public partial class MessageReplyResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-reply?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyResponse> MessageReplyAsync()
        {
            var p = new MessageReplyParameter();
            return await this.SendAsync<MessageReplyParameter, MessageReplyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyResponse> MessageReplyAsync(CancellationToken cancellationToken)
        {
            var p = new MessageReplyParameter();
            return await this.SendAsync<MessageReplyParameter, MessageReplyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyResponse> MessageReplyAsync(MessageReplyParameter parameter)
        {
            return await this.SendAsync<MessageReplyParameter, MessageReplyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-reply?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageReplyResponse> MessageReplyAsync(MessageReplyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageReplyParameter, MessageReplyResponse>(parameter, cancellationToken);
        }
    }
}
