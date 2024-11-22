using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetemailActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetEmailActivityUserCounts: return $"/reports/getEmailActivityUserCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetEmailActivityUserCounts,
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
public partial class ReportRootGetemailActivityUsercountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetemailActivityUsercountsResponse> ReportRootGetemailActivityUsercountsAsync()
    {
        var p = new ReportRootGetemailActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetemailActivityUsercountsParameter, ReportRootGetemailActivityUsercountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetemailActivityUsercountsResponse> ReportRootGetemailActivityUsercountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetemailActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetemailActivityUsercountsParameter, ReportRootGetemailActivityUsercountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetemailActivityUsercountsResponse> ReportRootGetemailActivityUsercountsAsync(ReportRootGetemailActivityUsercountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetemailActivityUsercountsParameter, ReportRootGetemailActivityUsercountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetemailActivityUsercountsResponse> ReportRootGetemailActivityUsercountsAsync(ReportRootGetemailActivityUsercountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetemailActivityUsercountsParameter, ReportRootGetemailActivityUsercountsResponse>(parameter, cancellationToken);
    }
}
