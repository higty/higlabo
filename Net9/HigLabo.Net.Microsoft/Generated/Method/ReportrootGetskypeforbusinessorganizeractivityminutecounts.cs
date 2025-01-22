using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityMinuteCounts: return $"/reports/getSkypeForBusinessOrganizerActivityMinuteCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSkypeForBusinessOrganizerActivityMinuteCounts,
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
public partial class ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse> ReportRootGetSkypeforBusinessorganizerActivityminutecountsAsync()
    {
        var p = new ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter, ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse> ReportRootGetSkypeforBusinessorganizerActivityminutecountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter, ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse> ReportRootGetSkypeforBusinessorganizerActivityminutecountsAsync(ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter, ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse> ReportRootGetSkypeforBusinessorganizerActivityminutecountsAsync(ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityminutecountsParameter, ReportRootGetSkypeforBusinessorganizerActivityminutecountsResponse>(parameter, cancellationToken);
    }
}
