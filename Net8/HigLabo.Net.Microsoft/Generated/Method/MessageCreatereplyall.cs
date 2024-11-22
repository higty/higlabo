using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-createreplyall?view=graph-rest-1.0
/// </summary>
public partial class MessageCreateReplyAllParameter : IRestApiParameter
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
                case ApiPath.Me_Messages_Id_CreateReplyAll: return $"/me/messages/{Id}/createReplyAll";
                case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_CreateReplyAll: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/createReplyAll";
                case ApiPath.Me_MailFolders_Id_Messages_Id_CreateReplyAll: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/createReplyAll";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_CreateReplyAll: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/createReplyAll";
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
        Me_Messages_Id_CreateReplyAll,
        Users_IdOrUserPrincipalName_Messages_Id_CreateReplyAll,
        Me_MailFolders_Id_Messages_Id_CreateReplyAll,
        Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_CreateReplyAll,
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
public partial class MessageCreateReplyAllResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/message-createreplyall?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-createreplyall?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageCreateReplyAllResponse> MessageCreateReplyAllAsync()
    {
        var p = new MessageCreateReplyAllParameter();
        return await this.SendAsync<MessageCreateReplyAllParameter, MessageCreateReplyAllResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-createreplyall?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageCreateReplyAllResponse> MessageCreateReplyAllAsync(CancellationToken cancellationToken)
    {
        var p = new MessageCreateReplyAllParameter();
        return await this.SendAsync<MessageCreateReplyAllParameter, MessageCreateReplyAllResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-createreplyall?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageCreateReplyAllResponse> MessageCreateReplyAllAsync(MessageCreateReplyAllParameter parameter)
    {
        return await this.SendAsync<MessageCreateReplyAllParameter, MessageCreateReplyAllResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-createreplyall?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageCreateReplyAllResponse> MessageCreateReplyAllAsync(MessageCreateReplyAllParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MessageCreateReplyAllParameter, MessageCreateReplyAllResponse>(parameter, cancellationToken);
    }
}
