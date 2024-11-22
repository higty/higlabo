using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSharepointActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSharePointActivityUserCounts: return $"/reports/getSharePointActivityUserCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSharePointActivityUserCounts,
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
public partial class ReportRootGetSharepointActivityUsercountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointActivityUsercountsResponse> ReportRootGetSharepointActivityUsercountsAsync()
    {
        var p = new ReportRootGetSharepointActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetSharepointActivityUsercountsParameter, ReportRootGetSharepointActivityUsercountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointActivityUsercountsResponse> ReportRootGetSharepointActivityUsercountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSharepointActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetSharepointActivityUsercountsParameter, ReportRootGetSharepointActivityUsercountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointActivityUsercountsResponse> ReportRootGetSharepointActivityUsercountsAsync(ReportRootGetSharepointActivityUsercountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSharepointActivityUsercountsParameter, ReportRootGetSharepointActivityUsercountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSharepointActivityUsercountsResponse> ReportRootGetSharepointActivityUsercountsAsync(ReportRootGetSharepointActivityUsercountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSharepointActivityUsercountsParameter, ReportRootGetSharepointActivityUsercountsResponse>(parameter, cancellationToken);
    }
}
