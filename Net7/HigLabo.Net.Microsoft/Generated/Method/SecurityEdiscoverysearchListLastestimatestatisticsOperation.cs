using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-lastestimatestatisticsoperation?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_LastEstimateStatisticsOperation: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/lastEstimateStatisticsOperation";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_LastEstimateStatisticsOperation,
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
    public partial class SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse : RestApiResponse
    {
        public enum EdiscoveryEstimateOperationSecurityCaseAction
        {
            AddToReviewSet,
            ApplyTags,
            ContentExport,
            ConvertToPdf,
            EstimateStatistics,
            PurgeData,
        }
        public enum EdiscoveryEstimateOperationSecurityCaseOperationStatus
        {
            NotStarted,
            SubmissionFailed,
            Running,
            Succeeded,
            PartiallySucceeded,
            Failed,
        }

        public EdiscoveryEstimateOperationSecurityCaseAction Action { get; set; }
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
        public EdiscoveryEstimateOperationSecurityCaseOperationStatus Status { get; set; }
        public Int64? UnindexedItemCount { get; set; }
        public Int64? UnindexedItemsSize { get; set; }
        public EdiscoverySearch? Search { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-lastestimatestatisticsoperation?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-lastestimatestatisticsoperation?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse> SecurityEdiscoverysearchListLastestimatestatisticsOperationAsync()
        {
            var p = new SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter();
            return await this.SendAsync<SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter, SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-lastestimatestatisticsoperation?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse> SecurityEdiscoverysearchListLastestimatestatisticsOperationAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter();
            return await this.SendAsync<SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter, SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-lastestimatestatisticsoperation?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse> SecurityEdiscoverysearchListLastestimatestatisticsOperationAsync(SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter, SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-lastestimatestatisticsoperation?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse> SecurityEdiscoverysearchListLastestimatestatisticsOperationAsync(SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchListLastestimatestatisticsOperationParameter, SecurityEdiscoverysearchListLastestimatestatisticsOperationResponse>(parameter, cancellationToken);
        }
    }
}
