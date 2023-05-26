using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class EventPostAttachmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? CalendarsId { get; set; }
            public string? EventsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }
            public string? CalendarGroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_Attachments: return $"/me/events/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/events/{Id}/attachments";
                    case ApiPath.Me_Calendar_Events_Id_Attachments: return $"/me/calendar/events/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/attachments";
                    case ApiPath.Me_Calendars_Id_Events_Id_Attachments: return $"/me/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Events_Id_Attachments,
            Me_Calendar_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_Attachments,
            Me_Calendars_Id_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments,
            Me_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Attachments,
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
    public partial class EventPostAttachmentsResponse : RestApiResponse
    {
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public bool? IsInline { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync()
        {
            var p = new EventPostAttachmentsParameter();
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventPostAttachmentsParameter();
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync(EventPostAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync(EventPostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
