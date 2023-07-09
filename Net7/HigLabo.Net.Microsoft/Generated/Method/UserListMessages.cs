using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-messages?view=graph-rest-1.0
    /// </summary>
    public partial class UserListMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Messages: return $"/me/messages";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages: return $"/users/{IdOrUserPrincipalName}/messages";
                    case ApiPath.Me_MailFolders_Id_Messages: return $"/me/mailFolders/{Id}/messages";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/messages";
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
            Me_Messages,
            Users_IdOrUserPrincipalName_Messages,
            Me_MailFolders_Id_Messages,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages,
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
    public partial class UserListMessagesResponse : RestApiResponse
    {
        public Message[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-messages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-messages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListMessagesResponse> UserListMessagesAsync()
        {
            var p = new UserListMessagesParameter();
            return await this.SendAsync<UserListMessagesParameter, UserListMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-messages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListMessagesResponse> UserListMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListMessagesParameter();
            return await this.SendAsync<UserListMessagesParameter, UserListMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-messages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListMessagesResponse> UserListMessagesAsync(UserListMessagesParameter parameter)
        {
            return await this.SendAsync<UserListMessagesParameter, UserListMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-messages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListMessagesResponse> UserListMessagesAsync(UserListMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListMessagesParameter, UserListMessagesResponse>(parameter, cancellationToken);
        }
    }
}
