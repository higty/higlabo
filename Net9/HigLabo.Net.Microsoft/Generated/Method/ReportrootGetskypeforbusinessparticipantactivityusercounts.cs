using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSkypeForBusinessParticipantActivityUserCounts: return $"/reports/getSkypeForBusinessParticipantActivityUserCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSkypeForBusinessParticipantActivityUserCounts,
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
public partial class ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse> ReportRootGetSkypeforBusinessparticipantActivityUsercountsAsync()
    {
        var p = new ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter, ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse> ReportRootGetSkypeforBusinessparticipantActivityUsercountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter, ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse> ReportRootGetSkypeforBusinessparticipantActivityUsercountsAsync(ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter, ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse> ReportRootGetSkypeforBusinessparticipantActivityUsercountsAsync(ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityUsercountsParameter, ReportRootGetSkypeforBusinessparticipantActivityUsercountsResponse>(parameter, cancellationToken);
    }
}
