using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListEventsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string Id { get; set; }
            public string CalendargroupsId { get; set; }
            public string CalendarsId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events: return $"/me/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Events: return $"/users/{IdOrUserPrincipalName}/events";
                    case ApiPath.Me_Calendar_Events: return $"/me/calendar/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events: return $"/users/{IdOrUserPrincipalName}/calendar/events";
                    case ApiPath.Me_Calendars_Id_Events: return $"/me/calendars/{Id}/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}/events";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events";
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
            Me_Events,
            Users_IdOrUserPrincipalName_Events,
            Me_Calendar_Events,
            Users_IdOrUserPrincipalName_Calendar_Events,
            Me_Calendars_Id_Events,
            Users_IdOrUserPrincipalName_Calendars_Id_Events,
            Me_Calendargroups_Id_Calendars_Id_Events,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events,
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
    public partial class UserListEventsResponse : RestApiResponse
    {
        public Event[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListEventsResponse> UserListEventsAsync()
        {
            var p = new UserListEventsParameter();
            return await this.SendAsync<UserListEventsParameter, UserListEventsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListEventsResponse> UserListEventsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListEventsParameter();
            return await this.SendAsync<UserListEventsParameter, UserListEventsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListEventsResponse> UserListEventsAsync(UserListEventsParameter parameter)
        {
            return await this.SendAsync<UserListEventsParameter, UserListEventsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListEventsResponse> UserListEventsAsync(UserListEventsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListEventsParameter, UserListEventsResponse>(parameter, cancellationToken);
        }
    }
}
