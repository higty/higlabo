using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewhistorydefinitionListInstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances: return $"/identityGovernance/accessReviews/historyDefinitions/{AccessReviewHistoryDefinitionId}/instances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string AccessReviewHistoryDefinitionId { get; set; }
    }
    public partial class AccessreviewhistorydefinitionListInstancesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewhistoryinstance?view=graph-rest-1.0
        /// </summary>
        public partial class AccessReviewHistoryInstance
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

        public AccessReviewHistoryInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync()
        {
            var p = new AccessreviewhistorydefinitionListInstancesParameter();
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewhistorydefinitionListInstancesParameter();
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync(AccessreviewhistorydefinitionListInstancesParameter parameter)
        {
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewhistorydefinitionListInstancesResponse> AccessreviewhistorydefinitionListInstancesAsync(AccessreviewhistorydefinitionListInstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewhistorydefinitionListInstancesParameter, AccessreviewhistorydefinitionListInstancesResponse>(parameter, cancellationToken);
        }
    }
}
