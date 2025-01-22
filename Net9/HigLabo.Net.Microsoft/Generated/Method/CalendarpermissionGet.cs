using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
/// </summary>
public partial class CalendarPermissionGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? UsersId { get; set; }
        public string? CalendarPermissionsId { get; set; }
        public string? GroupsId { get; set; }
        public string? EventsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_Id_Calendar_CalendarPermissions_Id: return $"/users/{UsersId}/calendar/calendarPermissions/{CalendarPermissionsId}";
                case ApiPath.Groups_Id_Calendar_CalendarPermissions_Id: return $"/groups/{GroupsId}/calendar/calendarPermissions/{CalendarPermissionsId}";
                case ApiPath.Users_Id_Events_Id_Calendar_CalendarPermissions_Id: return $"/users/{UsersId}/events/{EventsId}/calendar/calendarPermissions/{CalendarPermissionsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Users_Id_Calendar_CalendarPermissions_Id,
        Groups_Id_Calendar_CalendarPermissions_Id,
        Users_Id_Events_Id_Calendar_CalendarPermissions_Id,
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
public partial class CalendarPermissionGetResponse : RestApiResponse
{
    public enum CalendarPermissionCalendarRoleType
    {
        None,
        FreeBusyRead,
        LimitedRead,
        Read,
        Write,
        DelegateWithoutPrivateEventAccess,
        DelegateWithPrivateEventAccess,
        Custom,
    }

    public CalendarPermissionCalendarRoleType AllowedRoles { get; set; }
    public EmailAddress? EmailAddress { get; set; }
    public string? Id { get; set; }
    public bool? IsInsideOrganization { get; set; }
    public bool? IsRemovable { get; set; }
    public CalendarRoleType? Role { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarPermissionGetResponse> CalendarPermissionGetAsync()
    {
        var p = new CalendarPermissionGetParameter();
        return await this.SendAsync<CalendarPermissionGetParameter, CalendarPermissionGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarPermissionGetResponse> CalendarPermissionGetAsync(CancellationToken cancellationToken)
    {
        var p = new CalendarPermissionGetParameter();
        return await this.SendAsync<CalendarPermissionGetParameter, CalendarPermissionGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarPermissionGetResponse> CalendarPermissionGetAsync(CalendarPermissionGetParameter parameter)
    {
        return await this.SendAsync<CalendarPermissionGetParameter, CalendarPermissionGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendarpermission-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarPermissionGetResponse> CalendarPermissionGetAsync(CalendarPermissionGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CalendarPermissionGetParameter, CalendarPermissionGetResponse>(parameter, cancellationToken);
    }
}
