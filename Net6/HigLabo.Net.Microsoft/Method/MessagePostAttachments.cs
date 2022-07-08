using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessagePostAttachmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string MailFoldersId { get; set; }
            public string MessagesId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }
            public string ChildFoldersId { get; set; }
            public string AttachmentsId { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public bool? IsInline { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    public partial class MessagePostAttachmentsResponse : RestApiResponse
    {
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public bool? IsInline { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessagePostAttachmentsResponse> MessagePostAttachmentsAsync()
        {
            var p = new MessagePostAttachmentsParameter();
            return await this.SendAsync<MessagePostAttachmentsParameter, MessagePostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessagePostAttachmentsResponse> MessagePostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new MessagePostAttachmentsParameter();
            return await this.SendAsync<MessagePostAttachmentsParameter, MessagePostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessagePostAttachmentsResponse> MessagePostAttachmentsAsync(MessagePostAttachmentsParameter parameter)
        {
            return await this.SendAsync<MessagePostAttachmentsParameter, MessagePostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<MessagePostAttachmentsResponse> MessagePostAttachmentsAsync(MessagePostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessagePostAttachmentsParameter, MessagePostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
