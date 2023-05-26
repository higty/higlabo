using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class UserListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }
            public string? CalendarGroupsId { get; set; }
            public string? CalendarsId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Calendar_CalendarView: return $"/me/calendar/calendarView";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarView: return $"/users/{IdOrUserPrincipalName}/calendarView";
                    case ApiPath.Me_Calendars_Id_CalendarView: return $"/me/calendars/{Id}/calendarView";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_CalendarView: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}/calendarView";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_CalendarView: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/calendarView";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_CalendarView: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/calendarView";
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
            Me_Calendar_CalendarView,
            Users_IdOrUserPrincipalName_CalendarView,
            Me_Calendars_Id_CalendarView,
            Users_IdOrUserPrincipalName_Calendars_Id_CalendarView,
            Me_CalendarGroups_Id_Calendars_Id_CalendarView,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_CalendarView,
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
    public partial class UserListCalendarviewResponse : RestApiResponse
    {
        public Event[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarviewResponse> UserListCalendarviewAsync()
        {
            var p = new UserListCalendarviewParameter();
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarviewResponse> UserListCalendarviewAsync(CancellationToken cancellationToken)
        {
            var p = new UserListCalendarviewParameter();
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarviewResponse> UserListCalendarviewAsync(UserListCalendarviewParameter parameter)
        {
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendarviewResponse> UserListCalendarviewAsync(UserListCalendarviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListCalendarviewParameter, UserListCalendarviewResponse>(parameter, cancellationToken);
        }
    }
}
