using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
/// </summary>
public partial class ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetSkypeForBusinessParticipantActivityMinuteCounts: return $"/reports/getSkypeForBusinessParticipantActivityMinuteCounts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetSkypeForBusinessParticipantActivityMinuteCounts,
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
public partial class ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse> ReportRootGetSkypeforBusinessparticipantActivityminutecountsAsync()
    {
        var p = new ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter, ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse> ReportRootGetSkypeforBusinessparticipantActivityminutecountsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter();
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter, ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse> ReportRootGetSkypeforBusinessparticipantActivityminutecountsAsync(ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter parameter)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter, ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessparticipantactivityminutecounts?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse> ReportRootGetSkypeforBusinessparticipantActivityminutecountsAsync(ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootGetSkypeforBusinessparticipantActivityminutecountsParameter, ReportRootGetSkypeforBusinessparticipantActivityminutecountsResponse>(parameter, cancellationToken);
    }
}
