using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventPostAttachmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Events_Id_Attachments,
            Me_Calendar_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_Attachments,
            Me_Calendars_Id_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments,
            Me_Calendargroups_Id_Calendars_Id_Events_Id_Attachments,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Attachments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Events_Id_Attachments: return $"/me/events/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/events/{Id}/attachments";
                    case ApiPath.Me_Calendar_Events_Id_Attachments: return $"/me/calendar/events/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/attachments";
                    case ApiPath.Me_Calendars_Id_Events_Id_Attachments: return $"/me/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Attachments: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id_Attachments: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Attachments: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string CalendarsId { get; set; }
        public string EventsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string CalendargroupsId { get; set; }
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync()
        {
            var p = new EventPostAttachmentsParameter();
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventPostAttachmentsParameter();
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync(EventPostAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventPostAttachmentsResponse> EventPostAttachmentsAsync(EventPostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventPostAttachmentsParameter, EventPostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
