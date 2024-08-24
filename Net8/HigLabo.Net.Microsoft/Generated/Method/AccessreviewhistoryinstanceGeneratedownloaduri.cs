using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewHistoryinstanceGeneratedownloaduriParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewHistoryDefinitionId { get; set; }
            public string? AccessReviewHistoryInstanceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances_AccessReviewHistoryInstanceId_GenerateDownloadUri: return $"/identityGovernance/accessReviews/historyDefinitions/{AccessReviewHistoryDefinitionId}/instances/{AccessReviewHistoryInstanceId}/generateDownloadUri";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AccessReviewHistoryInstanceAccessReviewHistoryStatus
        {
            Done,
            InProgress,
            Error,
            Requested,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances_AccessReviewHistoryInstanceId_GenerateDownloadUri,
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
        public string? DownloadUri { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public DateTimeOffset? FulfilledDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        public DateTimeOffset? RunDateTime { get; set; }
        public AccessReviewHistoryInstanceAccessReviewHistoryStatus Status { get; set; }
    }
    public partial class AccessReviewHistoryinstanceGeneratedownloaduriResponse : RestApiResponse
    {
        public enum AccessReviewHistoryInstanceAccessReviewHistoryStatus
        {
            Done,
            InProgress,
            Error,
            Requested,
            UnknownFutureValue,
        }

        public string? DownloadUri { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public DateTimeOffset? FulfilledDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        public DateTimeOffset? RunDateTime { get; set; }
        public AccessReviewHistoryInstanceAccessReviewHistoryStatus Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewHistoryinstanceGeneratedownloaduriResponse> AccessReviewHistoryinstanceGeneratedownloaduriAsync()
        {
            var p = new AccessReviewHistoryinstanceGeneratedownloaduriParameter();
            return await this.SendAsync<AccessReviewHistoryinstanceGeneratedownloaduriParameter, AccessReviewHistoryinstanceGeneratedownloaduriResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewHistoryinstanceGeneratedownloaduriResponse> AccessReviewHistoryinstanceGeneratedownloaduriAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewHistoryinstanceGeneratedownloaduriParameter();
            return await this.SendAsync<AccessReviewHistoryinstanceGeneratedownloaduriParameter, AccessReviewHistoryinstanceGeneratedownloaduriResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewHistoryinstanceGeneratedownloaduriResponse> AccessReviewHistoryinstanceGeneratedownloaduriAsync(AccessReviewHistoryinstanceGeneratedownloaduriParameter parameter)
        {
            return await this.SendAsync<AccessReviewHistoryinstanceGeneratedownloaduriParameter, AccessReviewHistoryinstanceGeneratedownloaduriResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewHistoryinstanceGeneratedownloaduriResponse> AccessReviewHistoryinstanceGeneratedownloaduriAsync(AccessReviewHistoryinstanceGeneratedownloaduriParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewHistoryinstanceGeneratedownloaduriParameter, AccessReviewHistoryinstanceGeneratedownloaduriResponse>(parameter, cancellationToken);
        }
    }
}
