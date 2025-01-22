using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-estimatestatistics?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverysearchEstimatestatisticsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }
        public string? EdiscoverySearchId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_EstimateStatistics: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/estimateStatistics";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum EDiscoveryEstimateOperationSecurityCaseAction
    {
        AddToReviewSet,
        ApplyTags,
        ContentExport,
        ConvertToPdf,
        EstimateStatistics,
        PurgeData,
    }
    public enum EDiscoveryEstimateOperationSecurityCaseOperationStatus
    {
        NotStarted,
        SubmissionFailed,
        Running,
        Succeeded,
        PartiallySucceeded,
        Failed,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_EstimateStatistics,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public EDiscoveryEstimateOperationSecurityCaseAction Action { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Int64? IndexedItemCount { get; set; }
    public Int64? IndexedItemsSize { get; set; }
    public Int32? MailboxCount { get; set; }
    public Int32? PercentProgress { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public Int32? SiteCount { get; set; }
    public EDiscoveryEstimateOperationSecurityCaseOperationStatus Status { get; set; }
    public Int64? UnindexedItemCount { get; set; }
    public Int64? UnindexedItemsSize { get; set; }
    public EDiscoverySearch? Search { get; set; }
}
public partial class SecurityEDiscoverysearchEstimatestatisticsResponse : RestApiResponse
{
    public enum EDiscoveryEstimateOperationSecurityCaseAction
    {
        AddToReviewSet,
        ApplyTags,
        ContentExport,
        ConvertToPdf,
        EstimateStatistics,
        PurgeData,
    }
    public enum EDiscoveryEstimateOperationSecurityCaseOperationStatus
    {
        NotStarted,
        SubmissionFailed,
        Running,
        Succeeded,
        PartiallySucceeded,
        Failed,
    }

    public EDiscoveryEstimateOperationSecurityCaseAction Action { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Int64? IndexedItemCount { get; set; }
    public Int64? IndexedItemsSize { get; set; }
    public Int32? MailboxCount { get; set; }
    public Int32? PercentProgress { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public Int32? SiteCount { get; set; }
    public EDiscoveryEstimateOperationSecurityCaseOperationStatus Status { get; set; }
    public Int64? UnindexedItemCount { get; set; }
    public Int64? UnindexedItemsSize { get; set; }
    public EDiscoverySearch? Search { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-estimatestatistics?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-estimatestatistics?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchEstimatestatisticsResponse> SecurityEDiscoverysearchEstimatestatisticsAsync()
    {
        var p = new SecurityEDiscoverysearchEstimatestatisticsParameter();
        return await this.SendAsync<SecurityEDiscoverysearchEstimatestatisticsParameter, SecurityEDiscoverysearchEstimatestatisticsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-estimatestatistics?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchEstimatestatisticsResponse> SecurityEDiscoverysearchEstimatestatisticsAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverysearchEstimatestatisticsParameter();
        return await this.SendAsync<SecurityEDiscoverysearchEstimatestatisticsParameter, SecurityEDiscoverysearchEstimatestatisticsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-estimatestatistics?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchEstimatestatisticsResponse> SecurityEDiscoverysearchEstimatestatisticsAsync(SecurityEDiscoverysearchEstimatestatisticsParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverysearchEstimatestatisticsParameter, SecurityEDiscoverysearchEstimatestatisticsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-estimatestatistics?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchEstimatestatisticsResponse> SecurityEDiscoverysearchEstimatestatisticsAsync(SecurityEDiscoverysearchEstimatestatisticsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverysearchEstimatestatisticsParameter, SecurityEDiscoverysearchEstimatestatisticsResponse>(parameter, cancellationToken);
    }
}
