using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-accept?view=graph-rest-1.0
/// </summary>
public partial class EventAcceptParameter : IRestApiParameter
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
                case ApiPath.Me_Events_Id_Accept: return $"/me/events/{Id}/accept";
                case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Accept: return $"/users/{IdOrUserPrincipalName}/events/{Id}/accept";
                case ApiPath.Me_Calendar_Events_Id_Accept: return $"/me/calendar/events/{Id}/accept";
                case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events_Id_Accept: return $"/users/{IdOrUserPrincipalName}/calendar/events/{Id}/accept";
                case ApiPath.Me_Calendars_Id_Events_Id_Accept: return $"/me/calendars/{CalendarsId}/events/{EventsId}/accept";
                case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Accept: return $"/users/{UsersIdOrUserPrincipalName}/calendars/{CalendarsId}/events/{EventsId}/accept";
                case ApiPath.Me_CalendarGroups_Id_Calendars_Id_Events_Id_Accept: return $"/me/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/accept";
                case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Accept: return $"/users/{UsersIdOrUserPrincipalName}/calendarGroups/{CalendarGroupsId}/calendars/{CalendarsId}/events/{EventsId}/accept";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Events_Id_Accept,
        Users_IdOrUserPrincipalName_Events_Id_Accept,
        Me_Calendar_Events_Id_Accept,
        Users_IdOrUserPrincipalName_Calendar_Events_Id_Accept,
        Me_Calendars_Id_Events_Id_Accept,
        Users_IdOrUserPrincipalName_Calendars_Id_Events_Id_Accept,
        Me_CalendarGroups_Id_Calendars_Id_Events_Id_Accept,
        Users_IdOrUserPrincipalName_CalendarGroups_Id_Calendars_Id_Events_Id_Accept,
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
    public bool? SendResponse { get; set; }
}
public partial class EventAcceptResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-accept?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-accept?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventAcceptResponse> EventAcceptAsync()
    {
        var p = new EventAcceptParameter();
        return await this.SendAsync<EventAcceptParameter, EventAcceptResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-accept?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventAcceptResponse> EventAcceptAsync(CancellationToken cancellationToken)
    {
        var p = new EventAcceptParameter();
        return await this.SendAsync<EventAcceptParameter, EventAcceptResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-accept?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventAcceptResponse> EventAcceptAsync(EventAcceptParameter parameter)
    {
        return await this.SendAsync<EventAcceptParameter, EventAcceptResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-accept?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventAcceptResponse> EventAcceptAsync(EventAcceptParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EventAcceptParameter, EventAcceptResponse>(parameter, cancellationToken);
    }
}
