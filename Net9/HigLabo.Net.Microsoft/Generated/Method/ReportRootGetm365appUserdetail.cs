using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appuserdetail?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetM365appUserdetailParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetM365AppUserDetail: return $"/reports/getM365AppUserDetail";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetM365AppUserDetail,
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
public partial class ReportRootGetM365appUserdetailResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appuserdetail?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetM365appUserdetailResponse> ReportRootGetM365appUserdetailAsync()
    {
        var p = new ReportRootGetM365appUserdetailParameter();
        return await this.SendAsync<ReportRootGetM365appUserdetailParameter, ReportRootGetM365appUserdetailResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetM365appUserdetailResponse> ReportRootGetM365appUserdetailAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetM365appUserdetailParameter();
        return await this.SendAsync<ReportRootGetM365appUserdetailParameter, ReportRootGetM365appUserdetailResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetM365appUserdetailResponse> ReportRootGetM365appUserdetailAsync(ReportRootGetM365appUserdetailParameter parameter)
    {
        return await this.SendAsync<ReportRootGetM365appUserdetailParameter, ReportRootGetM365appUserdetailResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getm365appuserdetail?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetM365appUserdetailResponse> ReportRootGetM365appUserdetailAsync(ReportRootGetM365appUserdetailParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetM365appUserdetailParameter, ReportRootGetM365appUserdetailResponse>(parameter, cancellationToken);
    }
}
