using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
/// </summary>
public partial class CalendarGroupDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_CalendarGroups_Id: return $"/me/calendarGroups/{Id}";
                case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups_Id: return $"/users/{IdOrUserPrincipalName}/calendarGroups/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_CalendarGroups_Id,
        Users_IdOrUserPrincipalName_CalendarGroups_Id,
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
public partial class CalendarGroupDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupDeleteResponse> CalendarGroupDeleteAsync()
    {
        var p = new CalendarGroupDeleteParameter();
        return await this.SendAsync<CalendarGroupDeleteParameter, CalendarGroupDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupDeleteResponse> CalendarGroupDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new CalendarGroupDeleteParameter();
        return await this.SendAsync<CalendarGroupDeleteParameter, CalendarGroupDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupDeleteResponse> CalendarGroupDeleteAsync(CalendarGroupDeleteParameter parameter)
    {
        return await this.SendAsync<CalendarGroupDeleteParameter, CalendarGroupDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupDeleteResponse> CalendarGroupDeleteAsync(CalendarGroupDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CalendarGroupDeleteParameter, CalendarGroupDeleteResponse>(parameter, cancellationToken);
    }
}
