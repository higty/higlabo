using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
/// </summary>
public partial class MessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? MailFoldersId { get; set; }
        public string? MessagesId { get; set; }
        public string? UsersIdOrUserPrincipalName { get; set; }
        public string? ChildFoldersId { get; set; }
        public string? AttachmentsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Messages_Id_Attachments: return $"/me/messages/{Id}/attachments";
                case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/attachments";
                case ApiPath.Me_MailFolders_Id_Messages_Id_Attachments: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments";
                case ApiPath.Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id: return $"/me/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/.../messages/{MessagesId}/attachments/{AttachmentsId}";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

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
public partial class MessageListAttachmentsResponse : RestApiResponse<Attachment>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageListAttachmentsResponse> MessageListAttachmentsAsync()
    {
        var p = new MessageListAttachmentsParameter();
        return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageListAttachmentsResponse> MessageListAttachmentsAsync(CancellationToken cancellationToken)
    {
        var p = new MessageListAttachmentsParameter();
        return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageListAttachmentsResponse> MessageListAttachmentsAsync(MessageListAttachmentsParameter parameter)
    {
        return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MessageListAttachmentsResponse> MessageListAttachmentsAsync(MessageListAttachmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/message-list-attachments?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Attachment> MessageListAttachmentsEnumerateAsync(MessageListAttachmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<MessageListAttachmentsParameter, MessageListAttachmentsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Attachment>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
