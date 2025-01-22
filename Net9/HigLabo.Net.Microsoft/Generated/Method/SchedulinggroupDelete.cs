using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
/// </summary>
public partial class SchedulingGroupDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? TeamId { get; set; }
        public string? SchedulingGroupId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_TeamId_Schedule_SchedulingGroups_SchedulingGroupId: return $"/teams/{TeamId}/schedule/schedulingGroups/{SchedulingGroupId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_TeamId_Schedule_SchedulingGroups_SchedulingGroupId,
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
public partial class SchedulingGroupDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulingGroupDeleteResponse> SchedulingGroupDeleteAsync()
    {
        var p = new SchedulingGroupDeleteParameter();
        return await this.SendAsync<SchedulingGroupDeleteParameter, SchedulingGroupDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulingGroupDeleteResponse> SchedulingGroupDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new SchedulingGroupDeleteParameter();
        return await this.SendAsync<SchedulingGroupDeleteParameter, SchedulingGroupDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulingGroupDeleteResponse> SchedulingGroupDeleteAsync(SchedulingGroupDeleteParameter parameter)
    {
        return await this.SendAsync<SchedulingGroupDeleteParameter, SchedulingGroupDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchedulingGroupDeleteResponse> SchedulingGroupDeleteAsync(SchedulingGroupDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SchedulingGroupDeleteParameter, SchedulingGroupDeleteResponse>(parameter, cancellationToken);
    }
}
