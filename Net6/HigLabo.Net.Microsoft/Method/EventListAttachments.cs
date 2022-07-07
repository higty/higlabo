using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string CalendarsId { get; set; }
        public string EventsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string CalendargroupsId { get; set; }
    }
    public partial class EventListAttachmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/attachment?view=graph-rest-1.0
        /// </summary>
        public partial class Attachment
        {
            public string? ContentType { get; set; }
            public string? Id { get; set; }
            public bool? IsInline { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Int32? Size { get; set; }
        }

        public Attachment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync()
        {
            var p = new EventListAttachmentsParameter();
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventListAttachmentsParameter();
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync(EventListAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListAttachmentsResponse> EventListAttachmentsAsync(EventListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventListAttachmentsParameter, EventListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
