using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventListInstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Events_Id_Instances,
            Users_IdOrUserPrincipalName_Events_Id_Instances,
            Groups_Id_Events_Id_Instances,
            Me_Calendar_Events_Id_Instances,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_Instances,
            Groups_Id_Calendar_Events_Id_Instances,
            Me_Calendars_Id_Events_Id_Instances,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Instances,
            Me_Calendargroups_Id_Calendars_Id_Events_Id_Instances,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Instances,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Events_Id_Instances: return $"/me/events/{Id}/instances";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Instances: return $"/users/{IdOrUserPrincipalName}/events/{Id}/instances";
                    case ApiPath.Groups_Id_Events_Id_Instances: return $"/groups/{GroupsId}/events/{EventsId}/instances";
                    case ApiPath.Me_Calendar_Events_Id_Instances: return $"/me/calendar/events/{Id}/instances";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Instances: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/instances";
                    case ApiPath.Groups_Id_Calendar_Events_Id_Instances: return $"/groups/{GroupsId}/calendar/events/{EventsId}/instances";
                    case ApiPath.Me_Calendars_Id_Events_Id_Instances: return $"/me/calendars/{CalendarsId}/events/{EventsId}/instances";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Instances: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/instances";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id_Instances: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/instances";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Instances: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/instances";
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
        public string GroupsId { get; set; }
        public string EventsId { get; set; }
        public string CalendarsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string CalendargroupsId { get; set; }
    }
    public partial class EventListInstancesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/event?view=graph-rest-1.0
        /// </summary>
        public partial class Event
        {
            public enum EventImportance
            {
                Low,
                Normal,
                High,
            }
            public enum EventOnlineMeetingProviderType
            {
                Unknown,
                TeamsForBusiness,
                SkypeForBusiness,
                SkypeForConsumer,
            }

            public bool? AllowNewTimeProposals { get; set; }
            public Attendee[]? Attendees { get; set; }
            public ItemBody? Body { get; set; }
            public string? BodyPreview { get; set; }
            public String[]? Categories { get; set; }
            public string? ChangeKey { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeTimeZone? End { get; set; }
            public bool? HasAttachments { get; set; }
            public bool? HideAttendees { get; set; }
            public string? ICalUId { get; set; }
            public string? Id { get; set; }
            public EventImportance Importance { get; set; }
            public bool? IsAllDay { get; set; }
            public bool? IsCancelled { get; set; }
            public bool? IsDraft { get; set; }
            public bool? IsOnlineMeeting { get; set; }
            public bool? IsOrganizer { get; set; }
            public bool? IsReminderOn { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public Location? Location { get; set; }
            public Location[]? Locations { get; set; }
            public OnlineMeetingInfo? OnlineMeeting { get; set; }
            public EventOnlineMeetingProviderType OnlineMeetingProvider { get; set; }
            public string? OnlineMeetingUrl { get; set; }
            public Recipient? Organizer { get; set; }
            public string? OriginalEndTimeZone { get; set; }
            public DateTimeOffset? OriginalStart { get; set; }
            public string? OriginalStartTimeZone { get; set; }
            public PatternedRecurrence? Recurrence { get; set; }
            public Int32? ReminderMinutesBeforeStart { get; set; }
            public bool? ResponseRequested { get; set; }
            public ResponseStatus? ResponseStatus { get; set; }
            public string? Sensitivity { get; set; }
            public string? SeriesMasterId { get; set; }
            public string? ShowAs { get; set; }
            public DateTimeTimeZone? Start { get; set; }
            public string? Subject { get; set; }
            public string? TransactionId { get; set; }
            public string? Type { get; set; }
            public string? WebLink { get; set; }
        }

        public Event[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListInstancesResponse> EventListInstancesAsync()
        {
            var p = new EventListInstancesParameter();
            return await this.SendAsync<EventListInstancesParameter, EventListInstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListInstancesResponse> EventListInstancesAsync(CancellationToken cancellationToken)
        {
            var p = new EventListInstancesParameter();
            return await this.SendAsync<EventListInstancesParameter, EventListInstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListInstancesResponse> EventListInstancesAsync(EventListInstancesParameter parameter)
        {
            return await this.SendAsync<EventListInstancesParameter, EventListInstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<EventListInstancesResponse> EventListInstancesAsync(EventListInstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventListInstancesParameter, EventListInstancesResponse>(parameter, cancellationToken);
        }
    }
}
