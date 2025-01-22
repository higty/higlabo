using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSharepointsiteusagePagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSharePointSiteUsagePages: return $"/reports/getSharePointSiteUsagePages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSharePointSiteUsagePages,
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
public partial class ReportRootGetSharepointsiteusagePagesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagePagesResponse> ReportRootGetSharepointsiteusagePagesAsync()
    {
        var p = new ReportRootGetSharepointsiteusagePagesParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagePagesParameter, ReportRootGetSharepointsiteusagePagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagePagesResponse> ReportRootGetSharepointsiteusagePagesAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSharepointsiteusagePagesParameter();
        return await this.SendAsync<ReportRootGetSharepointsiteusagePagesParameter, ReportRootGetSharepointsiteusagePagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagePagesResponse> ReportRootGetSharepointsiteusagePagesAsync(ReportRootGetSharepointsiteusagePagesParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagePagesParameter, ReportRootGetSharepointsiteusagePagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointsiteusagePagesResponse> ReportRootGetSharepointsiteusagePagesAsync(ReportRootGetSharepointsiteusagePagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSharepointsiteusagePagesParameter, ReportRootGetSharepointsiteusagePagesResponse>(parameter, cancellationToken);
    }
}
