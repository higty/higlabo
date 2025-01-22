using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSharepointsiteusagedetailParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSharePointSiteUsageDetail: return $"/reports/getSharePointSiteUsageDetail";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSharePointSiteUsageDetail,
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
public partial class ReportRootGetSharepointsiteusagedetailResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagedetailResponse> ReportRootGetSharepointsiteusagedetailAsync()
    {
        var p = new ReportRootGetSharepointsiteusagedetailParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagedetailParameter, ReportRootGetSharepointsiteusagedetailResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagedetailResponse> ReportRootGetSharepointsiteusagedetailAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSharepointsiteusagedetailParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagedetailParameter, ReportRootGetSharepointsiteusagedetailResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagedetailResponse> ReportRootGetSharepointsiteusagedetailAsync(ReportRootGetSharepointsiteusagedetailParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagedetailParameter, ReportRootGetSharepointsiteusagedetailResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagedetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagedetailResponse> ReportRootGetSharepointsiteusagedetailAsync(ReportRootGetSharepointsiteusagedetailParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagedetailParameter, ReportRootGetSharepointsiteusagedetailResponse>(parameter, cancellationToken);
    }
}
