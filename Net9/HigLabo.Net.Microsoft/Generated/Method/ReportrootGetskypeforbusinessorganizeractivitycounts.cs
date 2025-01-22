using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSkypeforBusinessorganizerActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityCounts: return $"/reports/getSkypeForBusinessOrganizerActivityCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSkypeForBusinessOrganizerActivityCounts,
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
public partial class ReportRootGetSkypeforBusinessorganizerActivitycountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivitycountsResponse> ReportRootGetSkypeforBusinessorganizerActivitycountsAsync()
    {
        var p = new ReportRootGetSkypeforBusinessorganizerActivitycountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivitycountsParameter, ReportRootGetSkypeforBusinessorganizerActivitycountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivitycountsResponse> ReportRootGetSkypeforBusinessorganizerActivitycountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSkypeforBusinessorganizerActivitycountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivitycountsParameter, ReportRootGetSkypeforBusinessorganizerActivitycountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivitycountsResponse> ReportRootGetSkypeforBusinessorganizerActivitycountsAsync(ReportRootGetSkypeforBusinessorganizerActivitycountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivitycountsParameter, ReportRootGetSkypeforBusinessorganizerActivitycountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivitycountsResponse> ReportRootGetSkypeforBusinessorganizerActivitycountsAsync(ReportRootGetSkypeforBusinessorganizerActivitycountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivitycountsParameter, ReportRootGetSkypeforBusinessorganizerActivitycountsResponse>(parameter, cancellationToken);
    }
}
