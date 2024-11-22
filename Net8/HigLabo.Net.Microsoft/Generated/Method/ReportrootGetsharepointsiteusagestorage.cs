using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSharepointsiteusagestorageParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSharePointSiteUsageStorage: return $"/reports/getSharePointSiteUsageStorage";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSharePointSiteUsageStorage,
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
public partial class ReportRootGetSharepointsiteusagestorageResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagestorageResponse> ReportRootGetSharepointsiteusagestorageAsync()
    {
        var p = new ReportRootGetSharepointsiteusagestorageParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagestorageParameter, ReportRootGetSharepointsiteusagestorageResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagestorageResponse> ReportRootGetSharepointsiteusagestorageAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSharepointsiteusagestorageParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagestorageParameter, ReportRootGetSharepointsiteusagestorageResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagestorageResponse> ReportRootGetSharepointsiteusagestorageAsync(ReportRootGetSharepointsiteusagestorageParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagestorageParameter, ReportRootGetSharepointsiteusagestorageResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagestorageResponse> ReportRootGetSharepointsiteusagestorageAsync(ReportRootGetSharepointsiteusagestorageParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagestorageParameter, ReportRootGetSharepointsiteusagestorageResponse>(parameter, cancellationToken);
    }
}
