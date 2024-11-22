using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetOneDriveActivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetOneDriveActivityUserDetail: return $"/reports/getOneDriveActivityUserDetail";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetOneDriveActivityUserDetail,
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
public partial class ReportRootGetOneDriveActivityUserdetailResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetOneDriveActivityUserdetailResponse> ReportRootGetOneDriveActivityUserdetailAsync()
    {
        var p = new ReportRootGetOneDriveActivityUserdetailParameter();
        return await this.SendAsync<ReportRootGetOneDriveActivityUserdetailParameter, ReportRootGetOneDriveActivityUserdetailResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetOneDriveActivityUserdetailResponse> ReportRootGetOneDriveActivityUserdetailAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetOneDriveActivityUserdetailParameter();
        return await this.SendAsync<ReportRootGetOneDriveActivityUserdetailParameter, ReportRootGetOneDriveActivityUserdetailResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetOneDriveActivityUserdetailResponse> ReportRootGetOneDriveActivityUserdetailAsync(ReportRootGetOneDriveActivityUserdetailParameter parameter)
    {
        return await this.SendAsync<ReportRootGetOneDriveActivityUserdetailParameter, ReportRootGetOneDriveActivityUserdetailResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetOneDriveActivityUserdetailResponse> ReportRootGetOneDriveActivityUserdetailAsync(ReportRootGetOneDriveActivityUserdetailParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetOneDriveActivityUserdetailParameter, ReportRootGetOneDriveActivityUserdetailResponse>(parameter, cancellationToken);
    }
}
