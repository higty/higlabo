using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailFolders_Id_Messages_Delta,
            Users_Id_MailFolders_Id_Messages_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_MailFolders_Id_Messages_Delta: return $"/me/mailFolders/{Id}/messages/delta";
                    case ApiPath.Users_Id_MailFolders_Id_Messages_Delta: return $"/users/{UsersId}/mailFolders/{MailFoldersId}/messages/delta";
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
        public string UsersId { get; set; }
        public string MailFoldersId { get; set; }
    }
    public partial class MessageDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/message?view=graph-rest-1.0
        /// </summary>
        public partial class Message
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

        public Message[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageDeltaResponse> MessageDeltaAsync()
        {
            var p = new MessageDeltaParameter();
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageDeltaResponse> MessageDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new MessageDeltaParameter();
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageDeltaResponse> MessageDeltaAsync(MessageDeltaParameter parameter)
        {
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageDeltaResponse> MessageDeltaAsync(MessageDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(parameter, cancellationToken);
        }
    }
}
