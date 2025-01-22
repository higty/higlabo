using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
/// </summary>
public partial class CalendarGroupGetParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
public partial class CalendarGroupGetResponse : RestApiResponse
{
    public string? Name { get; set; }
    public string? ChangeKey { get; set; }
    public Guid? ClassId { get; set; }
    public string? Id { get; set; }
    public Calendar[]? Calendars { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupGetResponse> CalendarGroupGetAsync()
    {
        var p = new CalendarGroupGetParameter();
        return await this.SendAsync<CalendarGroupGetParameter, CalendarGroupGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupGetResponse> CalendarGroupGetAsync(CancellationToken cancellationToken)
    {
        var p = new CalendarGroupGetParameter();
        return await this.SendAsync<CalendarGroupGetParameter, CalendarGroupGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupGetResponse> CalendarGroupGetAsync(CalendarGroupGetParameter parameter)
    {
        return await this.SendAsync<CalendarGroupGetParameter, CalendarGroupGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/calendargroup-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CalendarGroupGetResponse> CalendarGroupGetAsync(CalendarGroupGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CalendarGroupGetParameter, CalendarGroupGetResponse>(parameter, cancellationToken);
    }
}
