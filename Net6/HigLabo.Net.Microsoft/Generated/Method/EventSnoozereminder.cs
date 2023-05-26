using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-snoozereminder?view=graph-rest-1.0
    /// </summary>
    public partial class EventSnoozereminderParameter : IRestApiParameter
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
                    case ApiPath.Me_Events_Id_SnoozeReminder: return $"/me/events/{Id}/snoozeReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_SnoozeReminder: return $"/users/{IdOrUserPrincipalName}/events/{Id}/snoozeReminder";
                    case ApiPath.Me_Calendar_Events_Id_SnoozeReminder: return $"/me/calendar/events/{Id}/snoozeReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_SnoozeReminder: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/snoozeReminder";
                    case ApiPath.Me_Calendars_Id_Events_Id_SnoozeReminder: return $"/me/calendars/{CalendarsId}/events/{EventsId}/snoozeReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_SnoozeReminder: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/snoozeReminder";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_SnoozeReminder: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/snoozeReminder";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_SnoozeReminder: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/snoozeReminder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_SnoozeReminder,
            Users_IdOrUserPrincipalName_Events_Id_SnoozeReminder,
            Me_Calendar_Events_Id_SnoozeReminder,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_SnoozeReminder,
            Me_Calendars_Id_Events_Id_SnoozeReminder,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_SnoozeReminder,
            Me_CalendarGroups_Id_Calendars_Id_Events_Id_SnoozeReminder,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_SnoozeReminder,
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
        public DateTimeTimeZone? NewReminderTime { get; set; }
    }
    public partial class EventSnoozereminderResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-snoozereminder?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-snoozereminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventSnoozereminderResponse> EventSnoozereminderAsync()
        {
            var p = new EventSnoozereminderParameter();
            return await this.SendAsync<EventSnoozereminderParameter, EventSnoozereminderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-snoozereminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventSnoozereminderResponse> EventSnoozereminderAsync(CancellationToken cancellationToken)
        {
            var p = new EventSnoozereminderParameter();
            return await this.SendAsync<EventSnoozereminderParameter, EventSnoozereminderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-snoozereminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventSnoozereminderResponse> EventSnoozereminderAsync(EventSnoozereminderParameter parameter)
        {
            return await this.SendAsync<EventSnoozereminderParameter, EventSnoozereminderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-snoozereminder?view=graph-rest-1.0
        /// </summary>
        public async Task<EventSnoozereminderResponse> EventSnoozereminderAsync(EventSnoozereminderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventSnoozereminderParameter, EventSnoozereminderResponse>(parameter, cancellationToken);
        }
    }
}
