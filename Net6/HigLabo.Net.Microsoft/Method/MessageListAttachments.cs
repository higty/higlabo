using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Messages_Id_Attachments,
            Users_IdOrUserPrincipalName_Messages_Id_Attachments,
            Me_MailFolders_Id_Messages_Id_Attachments,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments,
            Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages_Id_Attachments: return $"/me/messages/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/attachments";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_Attachments: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments";
                    case ApiPath.Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id: return $"/me/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/.../messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string MailFoldersId { get; set; }
        public string MessagesId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string ChildFoldersId { get; set; }
        public string AttachmentsId { get; set; }
    }
    public partial class MessageListAttachmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/attachment?view=graph-rest-1.0
        /// </summary>
        public partial class Attachment
        {
            public string? ContentType { get; set; }
            public string? Id { get; set; }
            public bool? IsInline { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Int32? Size { get; set; }
        }

        public Attachment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageListAttachmentsResponse> MessageListAttachmentsAsync()
        {
            var p = new MessageListAttachmentsParameter();
            return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageListAttachmentsResponse> MessageListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new MessageListAttachmentsParameter();
            return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageListAttachmentsResponse> MessageListAttachmentsAsync(MessageListAttachmentsParameter parameter)
        {
            return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageListAttachmentsResponse> MessageListAttachmentsAsync(MessageListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
