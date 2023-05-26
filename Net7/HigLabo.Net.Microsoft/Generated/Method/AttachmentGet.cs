using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
    /// </summary>
    public partial class AttachmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EventsId { get; set; }
            public string? AttachmentsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }
            public string? CalendarsId { get; set; }
            public string? CalendarGroupsId { get; set; }
            public string? MessagesId { get; set; }
            public string? MailFoldersId { get; set; }
            public string? ChildFoldersId { get; set; }
            public string? GroupsId { get; set; }
            public string? ThreadsId { get; set; }
            public string? PostsId { get; set; }
            public string? ConversationsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_Attachments_Id: return $"/me/events/{EventsId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/events/{EventsId}/attachments/{AttachmentsId}";
                    case ApiPath.Me_Events_Id_Attachments_Id_value: return $"/me/events/{EventsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Attachments_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/events/{EventsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Me_Calendars_Id_Events_Id_Attachments_Id: return $"/me/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}";
                    case ApiPath.Me_Calendars_Id_Events_Id_Attachments_Id_value: return $"/me/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id_value: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Me_Messages_Id_Attachments_Id: return $"/me/messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Me_Messages_Id_Attachments_Id_value: return $"/me/messages/{MessagesId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/messages/{MessagesId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_Attachments_Id: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Me_MailFolders_Id_Messages_Id_Attachments_Id_value: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id: return $"/me/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/.../messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}";
                    case ApiPath.Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id_value: return $"/me/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/.../messages/{MessagesId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id_value: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/childFolders/{ChildFoldersId}/messages/{MessagesId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Attachments_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/attachments/{AttachmentsId}";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments_Id: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/attachments/{AttachmentsId}";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Attachments_Id_value: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/attachments/{AttachmentsId}/$value";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments_Id_value: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/attachments/{AttachmentsId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ContentType,
            Id,
            IsInline,
            LastModifiedDateTime,
            Name,
            Size,
        }
        public enum ApiPath
        {
            Me_Events_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_Events_Id_Attachments_Id,
            Me_Events_Id_Attachments_Id_value,
            Users_IdOrUserPrincipalName_Events_Id_Attachments_Id_value,
            Me_Calendars_Id_Events_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments_Id,
            Me_Calendars_Id_Events_Id_Attachments_Id_value,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments_Id_value,
            Me_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id,
            Me_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id_value,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments_Id_value,
            Me_Messages_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_Messages_Id_Attachments_Id,
            Me_Messages_Id_Attachments_Id_value,
            Users_IdOrUserPrincipalName_Messages_Id_Attachments_Id_value,
            Me_MailFolders_Id_Messages_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments_Id,
            Me_MailFolders_Id_Messages_Id_Attachments_Id_value,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id_Attachments_Id_value,
            Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id,
            Me_MailFolders_Id_ChildFolders_Id__Messages_Id_Attachments_Id_value,
            Users_IdOrUserPrincipalName_MailFolders_Id_ChildFolders_Id_Messages_Id_Attachments_Id_value,
            Groups_Id_Threads_Id_Posts_Id_Attachments_Id,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments_Id,
            Groups_Id_Threads_Id_Posts_Id_Attachments_Id_value,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Attachments_Id_value,
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
    public partial class AttachmentGetResponse : RestApiResponse
    {
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public bool? IsInline { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentGetResponse> AttachmentGetAsync()
        {
            var p = new AttachmentGetParameter();
            return await this.SendAsync<AttachmentGetParameter, AttachmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentGetResponse> AttachmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new AttachmentGetParameter();
            return await this.SendAsync<AttachmentGetParameter, AttachmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentGetResponse> AttachmentGetAsync(AttachmentGetParameter parameter)
        {
            return await this.SendAsync<AttachmentGetParameter, AttachmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentGetResponse> AttachmentGetAsync(AttachmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttachmentGetParameter, AttachmentGetResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> AttachmentGetStreamAsync(AttachmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
