using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetTeamsdeviceusageUserdetailParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetTeamsDeviceUsageUserDetail: return $"/reports/getTeamsDeviceUsageUserDetail";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetTeamsDeviceUsageUserDetail,
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
public partial class ReportRootGetTeamsdeviceusageUserdetailResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsdeviceusageUserdetailResponse> ReportRootGetTeamsdeviceusageUserdetailAsync()
    {
        var p = new ReportRootGetTeamsdeviceusageUserdetailParameter();
        return await this.SendAsync<ReportRootGetTeamsdeviceusageUserdetailParameter, ReportRootGetTeamsdeviceusageUserdetailResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsdeviceusageUserdetailResponse> ReportRootGetTeamsdeviceusageUserdetailAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetTeamsdeviceusageUserdetailParameter();
        return await this.SendAsync<ReportRootGetTeamsdeviceusageUserdetailParameter, ReportRootGetTeamsdeviceusageUserdetailResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsdeviceusageUserdetailResponse> ReportRootGetTeamsdeviceusageUserdetailAsync(ReportRootGetTeamsdeviceusageUserdetailParameter parameter)
    {
        return await this.SendAsync<ReportRootGetTeamsdeviceusageUserdetailParameter, ReportRootGetTeamsdeviceusageUserdetailResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsdeviceusageuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetTeamsdeviceusageUserdetailResponse> ReportRootGetTeamsdeviceusageUserdetailAsync(ReportRootGetTeamsdeviceusageUserdetailParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetTeamsdeviceusageUserdetailParameter, ReportRootGetTeamsdeviceusageUserdetailResponse>(parameter, cancellationToken);
    }
}
