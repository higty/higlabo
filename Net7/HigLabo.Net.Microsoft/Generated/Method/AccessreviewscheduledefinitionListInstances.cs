using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewscheduledefinitionListInstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            EndDateTime,
            FallbackReviewers,
            Id,
            Reviewers,
            Scope,
            StartDateTime,
            Status,
            ContactedReviewers,
            Decisions,
            Stages,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances,
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
    public partial class AccessreviewscheduledefinitionListInstancesResponse : RestApiResponse
    {
        public AccessReviewInstance[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewscheduledefinitionListInstancesResponse> AccessreviewscheduledefinitionListInstancesAsync()
        {
            var p = new AccessreviewscheduledefinitionListInstancesParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionListInstancesParameter, AccessreviewscheduledefinitionListInstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewscheduledefinitionListInstancesResponse> AccessreviewscheduledefinitionListInstancesAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewscheduledefinitionListInstancesParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionListInstancesParameter, AccessreviewscheduledefinitionListInstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewscheduledefinitionListInstancesResponse> AccessreviewscheduledefinitionListInstancesAsync(AccessreviewscheduledefinitionListInstancesParameter parameter)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionListInstancesParameter, AccessreviewscheduledefinitionListInstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewscheduledefinitionListInstancesResponse> AccessreviewscheduledefinitionListInstancesAsync(AccessreviewscheduledefinitionListInstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionListInstancesParameter, AccessreviewscheduledefinitionListInstancesResponse>(parameter, cancellationToken);
        }
    }
}
