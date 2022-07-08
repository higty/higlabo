using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageCopyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string MailFoldersId { get; set; }
            public string MessagesId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Messages_Id_Copy: return $"/me/messages/{Id}/copy";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Copy: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/copy";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_Copy: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/copy";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Copy: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/copy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
        public enum ApiPath
        {
            Me_Messages_Id_Copy,
            Users_IdOrUserPrincipalName_Messages_Id_Copy,
            Me_MailFolders_Id_Messages_Id_Copy,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Copy,
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
        public string? DestinationId { get; set; }
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
        public Attachment[]? Attachments { get; set; }
        public Extension[]? Extensions { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MessageCopyResponse : RestApiResponse
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
        public Attachment[]? Attachments { get; set; }
        public Extension[]? Extensions { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCopyResponse> MessageCopyAsync()
        {
            var p = new MessageCopyParameter();
            return await this.SendAsync<MessageCopyParameter, MessageCopyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCopyResponse> MessageCopyAsync(CancellationToken cancellationToken)
        {
            var p = new MessageCopyParameter();
            return await this.SendAsync<MessageCopyParameter, MessageCopyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCopyResponse> MessageCopyAsync(MessageCopyParameter parameter)
        {
            return await this.SendAsync<MessageCopyParameter, MessageCopyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-copy?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageCopyResponse> MessageCopyAsync(MessageCopyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageCopyParameter, MessageCopyResponse>(parameter, cancellationToken);
        }
    }
}
