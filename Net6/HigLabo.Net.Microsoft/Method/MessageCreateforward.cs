using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageCreateforwardParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Messages_Id_CreateForward,
            Users_IdOrUserPrincipalName_Messages_Id_CreateForward,
            Me_MailFolders_Id_Messages_Id_CreateForward,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_CreateForward,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages_Id_CreateForward: return $"/me/messages/{Id}/createForward";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_CreateForward: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/createForward";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_CreateForward: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/createForward";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_CreateForward: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/createForward";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string MailFoldersId { get; set; }
        public string MessagesId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
    }
    public partial class MessageCreateforwardResponse : RestApiResponse
    {
        public enum MessageImportance
        {
            Low,
            Normal,
            High,
        }
        public enum MessageInferenceClassificationType
        {
            Focused,
            Other,
        }

        public Recipient[]? BccRecipients { get; set; }
        public ItemBody? Body { get; set; }
        public string? BodyPreview { get; set; }
        public String[]? Categories { get; set; }
        public Recipient[]? CcRecipients { get; set; }
        public string? ChangeKey { get; set; }
        public string? ConversationId { get; set; }
        public string? ConversationIndex { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public FollowupFlag? Flag { get; set; }
        public Recipient? From { get; set; }
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public MessageImportance Importance { get; set; }
        public MessageInferenceClassificationType InferenceClassification { get; set; }
        public InternetMessageHeader[]? InternetMessageHeaders { get; set; }
        public string? InternetMessageId { get; set; }
        public bool? IsDeliveryReceiptRequested { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsReadReceiptRequested { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? ParentFolderId { get; set; }
        public DateTimeOffset? ReceivedDateTime { get; set; }
        public Recipient[]? ReplyTo { get; set; }
        public Recipient? Sender { get; set; }
        public DateTimeOffset? SentDateTime { get; set; }
        public string? Subject { get; set; }
        public Recipient[]? ToRecipients { get; set; }
        public ItemBody? UniqueBody { get; set; }
        public string? WebLink { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-createforward?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCreateforwardResponse> MessageCreateforwardAsync()
        {
            var p = new MessageCreateforwardParameter();
            return await this.SendAsync<MessageCreateforwardParameter, MessageCreateforwardResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-createforward?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCreateforwardResponse> MessageCreateforwardAsync(CancellationToken cancellationToken)
        {
            var p = new MessageCreateforwardParameter();
            return await this.SendAsync<MessageCreateforwardParameter, MessageCreateforwardResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-createforward?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCreateforwardResponse> MessageCreateforwardAsync(MessageCreateforwardParameter parameter)
        {
            return await this.SendAsync<MessageCreateforwardParameter, MessageCreateforwardResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-createforward?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCreateforwardResponse> MessageCreateforwardAsync(MessageCreateforwardParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageCreateforwardParameter, MessageCreateforwardResponse>(parameter, cancellationToken);
        }
    }
}
