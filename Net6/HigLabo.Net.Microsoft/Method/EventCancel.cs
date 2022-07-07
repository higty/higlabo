using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventCancelParameter : IRestApiParameter
    {
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
            Me_Calendargroups_Id_Calendars_Id_Events_Id_Cancel,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Cancel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Events_Id_Cancel: return $"/me/events/{Id}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Cancel: return $"/users/{IdOrUserPrincipalName}/events/{Id}/cancel";
                    case ApiPath.Groups_Id_Events_Id_Cancel: return $"/groups/{GroupsId}/events/{EventsId}/cancel";
                    case ApiPath.Me_Calendar_Events_Id_Cancel: return $"/me/calendar/events/{Id}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Cancel: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/cancel";
                    case ApiPath.Groups_Id_Calendar_Events_Id_Cancel: return $"/groups/{GroupsId}/calendar/events/{EventsId}/cancel";
                    case ApiPath.Me_Calendars_Id_Events_Id_Cancel: return $"/me/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Cancel: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id_Cancel: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_Cancel: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Comment { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string EventsId { get; set; }
        public string CalendarsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string CalendargroupsId { get; set; }
    }
    public partial class EventCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<EventCancelResponse> EventCancelAsync()
        {
            var p = new EventCancelParameter();
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<EventCancelResponse> EventCancelAsync(CancellationToken cancellationToken)
        {
            var p = new EventCancelParameter();
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<EventCancelResponse> EventCancelAsync(EventCancelParameter parameter)
        {
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<EventCancelResponse> EventCancelAsync(EventCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventCancelParameter, EventCancelResponse>(parameter, cancellationToken);
        }
    }
}
