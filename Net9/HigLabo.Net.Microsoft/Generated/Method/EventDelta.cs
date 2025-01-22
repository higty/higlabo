using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
/// </summary>
public partial class EventDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_CalendarView_Delta: return $"/me/calendarView/delta";
                case ApiPath.Users_Id_CalendarView_Delta: return $"/users/{Id}/calendarView/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_CalendarView_Delta,
        Users_Id_CalendarView_Delta,
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
public partial class EventDeltaResponse : RestApiResponse<Event>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeltaResponse> EventDeltaAsync()
    {
        var p = new EventDeltaParameter();
        return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeltaResponse> EventDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new EventDeltaParameter();
        return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeltaResponse> EventDeltaAsync(EventDeltaParameter parameter)
    {
        return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EventDeltaResponse> EventDeltaAsync(EventDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Event> EventDeltaEnumerateAsync(EventDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Event>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
