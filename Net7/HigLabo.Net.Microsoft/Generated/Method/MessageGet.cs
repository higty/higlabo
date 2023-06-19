using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
    /// </summary>
    public partial class MessageGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Messages_Id: return $"/me/messages/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id: return $"/users/{IdOrUserPrincipalName}/messages/{Id}";
                    case ApiPath.Me_MailFolders_Id_Messages_Id: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}";
                    case ApiPath.Me_Messages_Id_value: return $"/me/messages/{Id}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_value: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/$value";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_value: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            BccRecipients,
            Body,
            BodyPreview,
            Categories,
            CcRecipients,
            ChangeKey,
            ConversationId,
            ConversationIndex,
            CreatedDateTime,
            Flag,
            From,
            HasAttachments,
            Id,
            Importance,
            InferenceClassification,
            InternetMessageHeaders,
            InternetMessageId,
            IsDeliveryReceiptRequested,
            IsDraft,
            IsRead,
            IsReadReceiptRequested,
            LastModifiedDateTime,
            ParentFolderId,
            ReceivedDateTime,
            ReplyTo,
            Sender,
            SentDateTime,
            Subject,
            ToRecipients,
            UniqueBody,
            WebLink,
            Attachments,
            Extensions,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_Messages_Id,
            Users_IdOrUserPrincipalName_Messages_Id,
            Me_MailFolders_Id_Messages_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id,
            Me_Messages_Id_value,
            Users_IdOrUserPrincipalName_Messages_Id_value,
            Me_MailFolders_Id_Messages_Id_value,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_value,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class MessageGetResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageGetResponse> MessageGetAsync()
        {
            var p = new MessageGetParameter();
            return await this.SendAsync<MessageGetParameter, MessageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageGetResponse> MessageGetAsync(CancellationToken cancellationToken)
        {
            var p = new MessageGetParameter();
            return await this.SendAsync<MessageGetParameter, MessageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageGetResponse> MessageGetAsync(MessageGetParameter parameter)
        {
            return await this.SendAsync<MessageGetParameter, MessageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageGetResponse> MessageGetAsync(MessageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageGetParameter, MessageGetResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Stream> MessageGetStreamAsync(MessageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
