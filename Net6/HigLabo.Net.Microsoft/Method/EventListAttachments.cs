using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class EventListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class EventListAttachmentsResponse : RestApiResponse
    {
        public Attachment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync()
        {
            var p = new EventListAttachmentsParameter();
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventListAttachmentsParameter();
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync(EventListAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync(EventListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
