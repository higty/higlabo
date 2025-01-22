using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
/// </summary>
public partial class EventDeleteParameter : IRestApiParameter
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
                case ApiPath.Me_Events_Id: return $"/me/events/{Id}";
                case ApiPath.Users_IdOrUserPrincipalName_Events_Id: return $"/users/{IdOrUserPrincipalName}/events/{Id}";
                case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                case ApiPath.Me_Calendar_Events_Id: return $"/me/calendar/events/{Id}";
                case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}";
                case ApiPath.Groups_Id_Calendar_Events_Id_: return $"/groups/{GroupsId}/calendar/events/{EventsId}/";
                case ApiPath.Me_Calendars_Id_Events_Id: return $"/me/calendars/{CalendarsId}/events/{EventsId}";
                case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}";
                case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}";
                case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Events_Id,
        Users_IdOrUserPrincipalName_Events_Id,
        Groups_Id_Events_Id,
        Me_Calendar_Events_Id,
        Users_IdOrUserPrincipalName_Calendar_Events_Id,
        Groups_Id_Calendar_Events_Id_,
        Me_Calendars_Id_Events_Id,
        Users_IdOrUserPrincipalName_Calendars_Id_Events_Id,
        Me_CalendarGroups_Id_Calendars_Id_Events_Id,
        Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class EventDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeleteResponse> EventDeleteAsync()
    {
        var p = new EventDeleteParameter();
        return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeleteResponse> EventDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new EventDeleteParameter();
        return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeleteResponse> EventDeleteAsync(EventDeleteParameter parameter)
    {
        return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeleteResponse> EventDeleteAsync(EventDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EventDeleteParameter, EventDeleteResponse>(parameter, cancellationToken);
    }
}
