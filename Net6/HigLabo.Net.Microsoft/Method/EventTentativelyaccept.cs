using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventTentativelyacceptParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string CalendarsId { get; set; }
            public string EventsId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }
            public string CalendargroupsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_TentativelyAccept: return $"/me/events/{Id}/tentativelyAccept";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_TentativelyAccept: return $"/users/{IdOrUserPrincipalName}/events/{Id}/tentativelyAccept";
                    case ApiPath.Me_Calendar_Events_Id_TentativelyAccept: return $"/me/calendar/events/{Id}/tentativelyAccept";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_TentativelyAccept: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/tentativelyAccept";
                    case ApiPath.Me_Calendars_Id_Events_Id_TentativelyAccept: return $"/me/calendars/{CalendarsId}/events/{EventsId}/tentativelyAccept";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_TentativelyAccept: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/tentativelyAccept";
                    case ApiPath.Me_Calendargroups_Id_Calendars_Id_Events_Id_TentativelyAccept: return $"/me/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/tentativelyAccept";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_TentativelyAccept: return $"/users/{UsersIdOrUserPrincipalName}/calendargroups/{CalendargroupsId}/calendars/{CalendarsId}/events/{EventsId}/tentativelyAccept";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_TentativelyAccept,
            Users_IdOrUserPrincipalName_Events_Id_TentativelyAccept,
            Me_Calendar_Events_Id_TentativelyAccept,
            Users_IdOrUserPrincipalName_Calendar_Events_Id_TentativelyAccept,
            Me_Calendars_Id_Events_Id_TentativelyAccept,
            Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_TentativelyAccept,
            Me_Calendargroups_Id_Calendars_Id_Events_Id_TentativelyAccept,
            Users_IdOrUserPrincipalName_Calendargroups_Id_Calendars_Id_Events_Id_TentativelyAccept,
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
        public TimeSlot? ProposedNewTime { get; set; }
        public bool? SendResponse { get; set; }
    }
    public partial class EventTentativelyacceptResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-tentativelyaccept?view=graph-rest-1.0
        /// </summary>
        public async Task<EventTentativelyacceptResponse> EventTentativelyacceptAsync()
        {
            var p = new EventTentativelyacceptParameter();
            return await this.SendAsync<EventTentativelyacceptParameter, EventTentativelyacceptResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-tentativelyaccept?view=graph-rest-1.0
        /// </summary>
        public async Task<EventTentativelyacceptResponse> EventTentativelyacceptAsync(CancellationToken cancellationToken)
        {
            var p = new EventTentativelyacceptParameter();
            return await this.SendAsync<EventTentativelyacceptParameter, EventTentativelyacceptResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-tentativelyaccept?view=graph-rest-1.0
        /// </summary>
        public async Task<EventTentativelyacceptResponse> EventTentativelyacceptAsync(EventTentativelyacceptParameter parameter)
        {
            return await this.SendAsync<EventTentativelyacceptParameter, EventTentativelyacceptResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-tentativelyaccept?view=graph-rest-1.0
        /// </summary>
        public async Task<EventTentativelyacceptResponse> EventTentativelyacceptAsync(EventTentativelyacceptParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventTentativelyacceptParameter, EventTentativelyacceptResponse>(parameter, cancellationToken);
        }
    }
}
