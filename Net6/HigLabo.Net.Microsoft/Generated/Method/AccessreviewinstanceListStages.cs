using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceListStagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }
            public string? AccessReviewInstanceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages";
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
            StartDateTime,
            Status,
            Decisions,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages,
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
    public partial class AccessreviewinstanceListStagesResponse : RestApiResponse
    {
        public AccessReviewStage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListStagesResponse> AccessreviewinstanceListStagesAsync()
        {
            var p = new AccessreviewinstanceListStagesParameter();
            return await this.SendAsync<AccessreviewinstanceListStagesParameter, AccessreviewinstanceListStagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListStagesResponse> AccessreviewinstanceListStagesAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceListStagesParameter();
            return await this.SendAsync<AccessreviewinstanceListStagesParameter, AccessreviewinstanceListStagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListStagesResponse> AccessreviewinstanceListStagesAsync(AccessreviewinstanceListStagesParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceListStagesParameter, AccessreviewinstanceListStagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListStagesResponse> AccessreviewinstanceListStagesAsync(AccessreviewinstanceListStagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceListStagesParameter, AccessreviewinstanceListStagesResponse>(parameter, cancellationToken);
        }
    }
}
