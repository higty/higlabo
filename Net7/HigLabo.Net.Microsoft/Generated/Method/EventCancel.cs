using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
    /// </summary>
    public partial class EventCancelParameter : IRestApiParameter
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
            public string? CalendarGroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_Cancel: return $"/me/events/{Id}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Cancel: return $"/users/{IdOrUserPrincipalName}/events/{Id}/cancel";
                    case ApiPath.Groups_Id_Events_Id_Cancel: return $"/groups/{GroupsId}/events/{EventsId}/cancel";
                    case ApiPath.Me_Calendar_Events_Id_Cancel: return $"/me/calendar/events/{Id}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Cancel: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/cancel";
                    case ApiPath.Groups_Id_Calendar_Events_Id_Cancel: return $"/groups/{GroupsId}/calendar/events/{EventsId}/cancel";
                    case ApiPath.Me_Calendars_Id_Events_Id_Cancel: return $"/me/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Cancel: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_Cancel: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Cancel: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_Cancel,
            Users_IdOrUserPrincipalName_Events_Id_Cancel,
            Groups_Id_Events_Id_Cancel,
            Me_Calendar_Events_Id_Cancel,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_Cancel,
            Groups_Id_Calendar_Events_Id_Cancel,
            Me_Calendars_Id_Events_Id_Cancel,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Cancel,
            Me_CalendarGroups_Id_Calendars_Id_Events_Id_Cancel,
            Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Cancel,
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
        public string? Comment { get; set; }
    }
    public partial class EventCancelResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventCancelResponse> EventCancelAsync()
        {
            var p = new EventCancelParameter();
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventCancelResponse> EventCancelAsync(CancellationToken cancellationToken)
        {
            var p = new EventCancelParameter();
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventCancelResponse> EventCancelAsync(EventCancelParameter parameter)
        {
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventCancelResponse> EventCancelAsync(EventCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(parameter, cancellationToken);
        }
    }
}
