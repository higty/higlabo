using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetoffice365GroupsActivityGroupcountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetOffice365GroupsActivityGroupCounts: return $"/reports/getOffice365GroupsActivityGroupCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetOffice365GroupsActivityGroupCounts,
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
public partial class ReportRootGetoffice365GroupsActivityGroupcountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivityGroupcountsResponse> ReportRootGetoffice365GroupsActivityGroupcountsAsync()
    {
        var p = new ReportRootGetoffice365GroupsActivityGroupcountsParameter();
        return await this.SendAsync<ReportRootGetoffice365GroupsActivityGroupcountsParameter, ReportRootGetoffice365GroupsActivityGroupcountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivityGroupcountsResponse> ReportRootGetoffice365GroupsActivityGroupcountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetoffice365GroupsActivityGroupcountsParameter();
        return await this.SendAsync<ReportRootGetoffice365GroupsActivityGroupcountsParameter, ReportRootGetoffice365GroupsActivityGroupcountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivityGroupcountsResponse> ReportRootGetoffice365GroupsActivityGroupcountsAsync(ReportRootGetoffice365GroupsActivityGroupcountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetoffice365GroupsActivityGroupcountsParameter, ReportRootGetoffice365GroupsActivityGroupcountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetoffice365GroupsActivityGroupcountsResponse> ReportRootGetoffice365GroupsActivityGroupcountsAsync(ReportRootGetoffice365GroupsActivityGroupcountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetoffice365GroupsActivityGroupcountsParameter, ReportRootGetoffice365GroupsActivityGroupcountsResponse>(parameter, cancellationToken);
    }
}
