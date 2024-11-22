using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetyammerActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetYammerActivityUserCounts: return $"/reports/getYammerActivityUserCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetYammerActivityUserCounts,
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
public partial class ReportRootGetyammerActivityUsercountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerActivityUsercountsResponse> ReportRootGetyammerActivityUsercountsAsync()
    {
        var p = new ReportRootGetyammerActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetyammerActivityUsercountsParameter, ReportRootGetyammerActivityUsercountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerActivityUsercountsResponse> ReportRootGetyammerActivityUsercountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetyammerActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetyammerActivityUsercountsParameter, ReportRootGetyammerActivityUsercountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerActivityUsercountsResponse> ReportRootGetyammerActivityUsercountsAsync(ReportRootGetyammerActivityUsercountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetyammerActivityUsercountsParameter, ReportRootGetyammerActivityUsercountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetyammerActivityUsercountsResponse> ReportRootGetyammerActivityUsercountsAsync(ReportRootGetyammerActivityUsercountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetyammerActivityUsercountsParameter, ReportRootGetyammerActivityUsercountsResponse>(parameter, cancellationToken);
    }
}
