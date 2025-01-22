using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSharepointsiteusagesitecountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSharePointSiteUsageSiteCounts: return $"/reports/getSharePointSiteUsageSiteCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSharePointSiteUsageSiteCounts,
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
public partial class ReportRootGetSharepointsiteusagesitecountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagesitecountsResponse> ReportRootGetSharepointsiteusagesitecountsAsync()
    {
        var p = new ReportRootGetSharepointsiteusagesitecountsParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagesitecountsParameter, ReportRootGetSharepointsiteusagesitecountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagesitecountsResponse> ReportRootGetSharepointsiteusagesitecountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSharepointsiteusagesitecountsParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagesitecountsParameter, ReportRootGetSharepointsiteusagesitecountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagesitecountsResponse> ReportRootGetSharepointsiteusagesitecountsAsync(ReportRootGetSharepointsiteusagesitecountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagesitecountsParameter, ReportRootGetSharepointsiteusagesitecountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagesitecountsResponse> ReportRootGetSharepointsiteusagesitecountsAsync(ReportRootGetSharepointsiteusagesitecountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagesitecountsParameter, ReportRootGetSharepointsiteusagesitecountsResponse>(parameter, cancellationToken);
    }
}
