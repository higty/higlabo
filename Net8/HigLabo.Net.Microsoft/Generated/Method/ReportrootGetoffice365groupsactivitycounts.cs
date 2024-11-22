using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetoffice365GroupsActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetOffice365GroupsActivityCounts: return $"/reports/getOffice365GroupsActivityCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetOffice365GroupsActivityCounts,
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
public partial class ReportRootGetoffice365GroupsActivitycountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivitycountsResponse> ReportRootGetoffice365GroupsActivitycountsAsync()
    {
        var p = new ReportRootGetoffice365GroupsActivitycountsParameter();
        return await this.SendAsync<ReportRootGetoffice365GroupsActivitycountsParameter, ReportRootGetoffice365GroupsActivitycountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivitycountsResponse> ReportRootGetoffice365GroupsActivitycountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetoffice365GroupsActivitycountsParameter();
        return await this.SendAsync<ReportRootGetoffice365GroupsActivitycountsParameter, ReportRootGetoffice365GroupsActivitycountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivitycountsResponse> ReportRootGetoffice365GroupsActivitycountsAsync(ReportRootGetoffice365GroupsActivitycountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetoffice365GroupsActivitycountsParameter, ReportRootGetoffice365GroupsActivitycountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivitycountsResponse> ReportRootGetoffice365GroupsActivitycountsAsync(ReportRootGetoffice365GroupsActivitycountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetoffice365GroupsActivitycountsParameter, ReportRootGetoffice365GroupsActivitycountsResponse>(parameter, cancellationToken);
    }
}
