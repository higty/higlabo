using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetyammerGroupsActivityGroupcountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetYammerGroupsActivityGroupCounts: return $"/reports/getYammerGroupsActivityGroupCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetYammerGroupsActivityGroupCounts,
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
public partial class ReportRootGetyammerGroupsActivityGroupcountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivityGroupcountsResponse> ReportRootGetyammerGroupsActivityGroupcountsAsync()
    {
        var p = new ReportRootGetyammerGroupsActivityGroupcountsParameter();
        return await this.SendAsync<ReportRootGetyammerGroupsActivityGroupcountsParameter, ReportRootGetyammerGroupsActivityGroupcountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivityGroupcountsResponse> ReportRootGetyammerGroupsActivityGroupcountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetyammerGroupsActivityGroupcountsParameter();
        return await this.SendAsync<ReportRootGetyammerGroupsActivityGroupcountsParameter, ReportRootGetyammerGroupsActivityGroupcountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivityGroupcountsResponse> ReportRootGetyammerGroupsActivityGroupcountsAsync(ReportRootGetyammerGroupsActivityGroupcountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetyammerGroupsActivityGroupcountsParameter, ReportRootGetyammerGroupsActivityGroupcountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivityGroupcountsResponse> ReportRootGetyammerGroupsActivityGroupcountsAsync(ReportRootGetyammerGroupsActivityGroupcountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetyammerGroupsActivityGroupcountsParameter, ReportRootGetyammerGroupsActivityGroupcountsResponse>(parameter, cancellationToken);
    }
}
