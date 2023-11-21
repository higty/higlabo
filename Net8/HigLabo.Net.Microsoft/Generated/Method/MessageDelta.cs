using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MessageDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? UsersId { get; set; }
            public string? MailFoldersId { get; set; }
            public string? MailfoldersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailFolders_Id_Messages_Delta: return $"/me/mailFolders/{Id}/messages/delta";
                    case ApiPath.Users_Id_MailFolders_Id_Messages_Delta: return $"/users/{UsersId}/mailFolders/{MailFoldersId}/messages/delta";
                    case ApiPath.Users_Id_Mailfolders_Id_Messages_Delta: return $"/users/{UsersId}/mailfolders/{MailfoldersId}/messages/delta";
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
            Me_MailFolders_Id_Messages_Delta,
            Users_Id_MailFolders_Id_Messages_Delta,
            Users_Id_Mailfolders_Id_Messages_Delta,
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
    public partial class MessageDeltaResponse : RestApiResponse
    {
        public Message[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageDeltaResponse> MessageDeltaAsync()
        {
            var p = new MessageDeltaParameter();
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageDeltaResponse> MessageDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new MessageDeltaParameter();
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageDeltaResponse> MessageDeltaAsync(MessageDeltaParameter parameter)
        {
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/message-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<MessageDeltaResponse> MessageDeltaAsync(MessageDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageDeltaParameter, MessageDeltaResponse>(parameter, cancellationToken);
        }
    }
}
