using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
/// </summary>
public partial class ScheduleListSchedulingGroupsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule_SchedulingGroups: return $"/teams/{TeamId}/schedule/schedulingGroups";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_TeamId_Schedule_SchedulingGroups,
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
public partial class ScheduleListSchedulingGroupsResponse : RestApiResponse<SchedulingGroup>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListSchedulingGroupsResponse> ScheduleListSchedulingGroupsAsync()
    {
        var p = new ScheduleListSchedulingGroupsParameter();
        return await this.SendAsync<ScheduleListSchedulingGroupsParameter, ScheduleListSchedulingGroupsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListSchedulingGroupsResponse> ScheduleListSchedulingGroupsAsync(CancellationToken cancellationToken)
    {
        var p = new ScheduleListSchedulingGroupsParameter();
        return await this.SendAsync<ScheduleListSchedulingGroupsParameter, ScheduleListSchedulingGroupsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListSchedulingGroupsResponse> ScheduleListSchedulingGroupsAsync(ScheduleListSchedulingGroupsParameter parameter)
    {
        return await this.SendAsync<ScheduleListSchedulingGroupsParameter, ScheduleListSchedulingGroupsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ScheduleListSchedulingGroupsResponse> ScheduleListSchedulingGroupsAsync(ScheduleListSchedulingGroupsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ScheduleListSchedulingGroupsParameter, ScheduleListSchedulingGroupsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SchedulingGroup> ScheduleListSchedulingGroupsEnumerateAsync(ScheduleListSchedulingGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ScheduleListSchedulingGroupsParameter, ScheduleListSchedulingGroupsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SchedulingGroup>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
