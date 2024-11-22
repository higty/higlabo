using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetyammerGroupsActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetYammerGroupsActivityCounts: return $"/reports/getYammerGroupsActivityCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetYammerGroupsActivityCounts,
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
public partial class ReportRootGetyammerGroupsActivitycountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivitycountsResponse> ReportRootGetyammerGroupsActivitycountsAsync()
    {
        var p = new ReportRootGetyammerGroupsActivitycountsParameter();
        return await this.SendAsync<ReportRootGetyammerGroupsActivitycountsParameter, ReportRootGetyammerGroupsActivitycountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivitycountsResponse> ReportRootGetyammerGroupsActivitycountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetyammerGroupsActivitycountsParameter();
        return await this.SendAsync<ReportRootGetyammerGroupsActivitycountsParameter, ReportRootGetyammerGroupsActivitycountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivitycountsResponse> ReportRootGetyammerGroupsActivitycountsAsync(ReportRootGetyammerGroupsActivitycountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetyammerGroupsActivitycountsParameter, ReportRootGetyammerGroupsActivitycountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerGroupsActivitycountsResponse> ReportRootGetyammerGroupsActivitycountsAsync(ReportRootGetyammerGroupsActivitycountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetyammerGroupsActivitycountsParameter, ReportRootGetyammerGroupsActivitycountsResponse>(parameter, cancellationToken);
    }
}
