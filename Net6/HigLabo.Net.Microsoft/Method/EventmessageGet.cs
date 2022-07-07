using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventmessageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Messages_Id,
            Users_IdOrUserPrincipalName_Messages_Id,
            Me_MailFolders_Id_Messages_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages_Id: return $"/me/messages/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id: return $"/users/{IdOrUserPrincipalName}/messages/{Id}";
                    case ApiPath.Me_MailFolders_Id_Messages_Id: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}";
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
    }
    public partial class EventmessageGetResponse : RestApiResponse
    {
        public enum EventMessageMeetingMessageType
        {
            None,
            MeetingRequest,
            MeetingCancelled,
            MeetingAccepted,
            MeetingTenativelyAccepted,
            MeetingDeclined,
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
        public string? Importance { get; set; }
        public string? InferenceClassification { get; set; }
        public InternetMessageHeader[]? InternetMessageHeaders { get; set; }
        public string? InternetMessageId { get; set; }
        public bool? IsDelegated { get; set; }
        public bool? IsDeliveryReceiptRequested { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsReadReceiptRequested { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EventMessageMeetingMessageType MeetingMessageType { get; set; }
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
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageGetResponse> EventmessageGetAsync()
        {
            var p = new EventmessageGetParameter();
            return await this.SendAsync<EventmessageGetParameter, EventmessageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageGetResponse> EventmessageGetAsync(CancellationToken cancellationToken)
        {
            var p = new EventmessageGetParameter();
            return await this.SendAsync<EventmessageGetParameter, EventmessageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageGetResponse> EventmessageGetAsync(EventmessageGetParameter parameter)
        {
            return await this.SendAsync<EventmessageGetParameter, EventmessageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageGetResponse> EventmessageGetAsync(EventmessageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventmessageGetParameter, EventmessageGetResponse>(parameter, cancellationToken);
        }
    }
}
