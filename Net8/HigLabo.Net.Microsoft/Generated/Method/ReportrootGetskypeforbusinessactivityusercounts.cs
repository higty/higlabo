using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSkypeforBusinessActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSkypeForBusinessActivityUserCounts: return $"/reports/getSkypeForBusinessActivityUserCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSkypeForBusinessActivityUserCounts,
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
public partial class ReportRootGetSkypeforBusinessActivityUsercountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessActivityUsercountsResponse> ReportRootGetSkypeforBusinessActivityUsercountsAsync()
    {
        var p = new ReportRootGetSkypeforBusinessActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessActivityUsercountsParameter, ReportRootGetSkypeforBusinessActivityUsercountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessActivityUsercountsResponse> ReportRootGetSkypeforBusinessActivityUsercountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSkypeforBusinessActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessActivityUsercountsParameter, ReportRootGetSkypeforBusinessActivityUsercountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessActivityUsercountsResponse> ReportRootGetSkypeforBusinessActivityUsercountsAsync(ReportRootGetSkypeforBusinessActivityUsercountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessActivityUsercountsParameter, ReportRootGetSkypeforBusinessActivityUsercountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessActivityUsercountsResponse> ReportRootGetSkypeforBusinessActivityUsercountsAsync(ReportRootGetSkypeforBusinessActivityUsercountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessActivityUsercountsParameter, ReportRootGetSkypeforBusinessActivityUsercountsResponse>(parameter, cancellationToken);
    }
}
