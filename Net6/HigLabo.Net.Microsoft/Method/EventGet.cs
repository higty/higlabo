using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? EventsId { get; set; }
            public string? CalendarsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }
            public string? CalendargroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id: return $"/me/events/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id: return $"/users/{IdOrUserPrincipalName}/events/{Id}";
                    case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                    case ApiPath.Me_Calendar_Events_Id: return $"/me/calendar/events/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}";
                    case ApiPath.Groups_Id_Calendar_Events_Id: return $"/groups/{GroupsId}/calendar/events/{EventsId}";
                    case ApiPath.Me_Calendars_Id_Events_Id: return $"/me/calendars/{CalendarsId}/events/{EventsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowNewTimeProposals,
            Attendees,
            Body,
            BodyPreview,
            Categories,
            ChangeKey,
            CreatedDateTime,
            End,
            HasAttachments,
            HideAttendees,
            ICalUId,
            Id,
            Importance,
            IsAllDay,
            IsCancelled,
            IsDraft,
            IsOnlineMeeting,
            IsOrganizer,
            IsReminderOn,
            LastModifiedDateTime,
            Location,
            Locations,
            OnlineMeeting,
            OnlineMeetingProvider,
            OnlineMeetingUrl,
            Organizer,
            OriginalEndTimeZone,
            OriginalStart,
            OriginalStartTimeZone,
            Recurrence,
            ReminderMinutesBeforeStart,
            ResponseRequested,
            ResponseStatus,
            Sensitivity,
            SeriesMasterId,
            ShowAs,
            Start,
            Subject,
            TransactionId,
            Type,
            WebLink,
            Attachments,
            Calendar,
            Extensions,
            Instances,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Me_Events_Id,
            Users_IdOrUserPrincipalName_Events_Id,
            Groups_Id_Events_Id,
            Me_Calendar_Events_Id,
            Users_IdOrUserPrincipalName_Calendar_Events_Id,
            Groups_Id_Calendar_Events_Id,
            Me_Calendars_Id_Events_Id,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id,
            Me_Calendargroups_Id_Calendars_Id_Events_Id,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id,
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
    public partial class EventGetResponse : RestApiResponse
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
        public Attachment[]? Attachments { get; set; }
        public Calendar? Calendar { get; set; }
        public Extension[]? Extensions { get; set; }
        public Event[]? Instances { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventGetResponse> EventGetAsync()
        {
            var p = new EventGetParameter();
            return await this.SendAsync<EventGetParameter, EventGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventGetResponse> EventGetAsync(CancellationToken cancellationToken)
        {
            var p = new EventGetParameter();
            return await this.SendAsync<EventGetParameter, EventGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventGetResponse> EventGetAsync(EventGetParameter parameter)
        {
            return await this.SendAsync<EventGetParameter, EventGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EventGetResponse> EventGetAsync(EventGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventGetParameter, EventGetResponse>(parameter, cancellationToken);
        }
    }
}
