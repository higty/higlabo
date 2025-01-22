using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetoffice365activationsUsercountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetOffice365ActivationsUserCounts: return $"/reports/getOffice365ActivationsUserCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetOffice365ActivationsUserCounts,
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
public partial class ReportRootGetoffice365activationsUsercountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365activationsUsercountsResponse> ReportRootGetoffice365activationsUsercountsAsync()
    {
        var p = new ReportRootGetoffice365activationsUsercountsParameter();
        return await this.SendAsync<ReportRootGetoffice365activationsUsercountsParameter, ReportRootGetoffice365activationsUsercountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365activationsUsercountsResponse> ReportRootGetoffice365activationsUsercountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetoffice365activationsUsercountsParameter();
        return await this.SendAsync<ReportRootGetoffice365activationsUsercountsParameter, ReportRootGetoffice365activationsUsercountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365activationsUsercountsResponse> ReportRootGetoffice365activationsUsercountsAsync(ReportRootGetoffice365activationsUsercountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetoffice365activationsUsercountsParameter, ReportRootGetoffice365activationsUsercountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365activationsUsercountsResponse> ReportRootGetoffice365activationsUsercountsAsync(ReportRootGetoffice365activationsUsercountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetoffice365activationsUsercountsParameter, ReportRootGetoffice365activationsUsercountsResponse>(parameter, cancellationToken);
    }
}
