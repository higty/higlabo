using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewhistoryinstanceGeneratedownloaduriParameter : IRestApiParameter
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
    public partial class AccessreviewhistoryinstanceGeneratedownloaduriResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistoryinstanceGeneratedownloaduriResponse> AccessreviewhistoryinstanceGeneratedownloaduriAsync()
        {
            var p = new AccessreviewhistoryinstanceGeneratedownloaduriParameter();
            return await this.SendAsync<AccessreviewhistoryinstanceGeneratedownloaduriParameter, AccessreviewhistoryinstanceGeneratedownloaduriResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistoryinstanceGeneratedownloaduriResponse> AccessreviewhistoryinstanceGeneratedownloaduriAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewhistoryinstanceGeneratedownloaduriParameter();
            return await this.SendAsync<AccessreviewhistoryinstanceGeneratedownloaduriParameter, AccessreviewhistoryinstanceGeneratedownloaduriResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistoryinstanceGeneratedownloaduriResponse> AccessreviewhistoryinstanceGeneratedownloaduriAsync(AccessreviewhistoryinstanceGeneratedownloaduriParameter parameter)
        {
            return await this.SendAsync<AccessreviewhistoryinstanceGeneratedownloaduriParameter, AccessreviewhistoryinstanceGeneratedownloaduriResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistoryinstance-generatedownloaduri?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistoryinstanceGeneratedownloaduriResponse> AccessreviewhistoryinstanceGeneratedownloaduriAsync(AccessreviewhistoryinstanceGeneratedownloaduriParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewhistoryinstanceGeneratedownloaduriParameter, AccessreviewhistoryinstanceGeneratedownloaduriResponse>(parameter, cancellationToken);
        }
    }
}
