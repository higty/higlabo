using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSharepointsiteusagefilecountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSharePointSiteUsageFileCounts: return $"/reports/getSharePointSiteUsageFileCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSharePointSiteUsageFileCounts,
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
public partial class ReportRootGetSharepointsiteusagefilecountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagefilecountsResponse> ReportRootGetSharepointsiteusagefilecountsAsync()
    {
        var p = new ReportRootGetSharepointsiteusagefilecountsParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagefilecountsParameter, ReportRootGetSharepointsiteusagefilecountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagefilecountsResponse> ReportRootGetSharepointsiteusagefilecountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSharepointsiteusagefilecountsParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagefilecountsParameter, ReportRootGetSharepointsiteusagefilecountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagefilecountsResponse> ReportRootGetSharepointsiteusagefilecountsAsync(ReportRootGetSharepointsiteusagefilecountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagefilecountsParameter, ReportRootGetSharepointsiteusagefilecountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagefilecountsResponse> ReportRootGetSharepointsiteusagefilecountsAsync(ReportRootGetSharepointsiteusagefilecountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagefilecountsParameter, ReportRootGetSharepointsiteusagefilecountsResponse>(parameter, cancellationToken);
    }
}
