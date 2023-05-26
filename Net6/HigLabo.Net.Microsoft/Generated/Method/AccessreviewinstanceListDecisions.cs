using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceListDecisionsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AccessReviewId,
            AppliedBy,
            AppliedDateTime,
            ApplyResult,
            Decision,
            Id,
            Justification,
            Principal,
            PrincipalLink,
            Recommendation,
            Resource,
            ResourceLink,
            ReviewedBy,
            ReviewedDateTime,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions,
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
    public partial class AccessreviewinstanceListDecisionsResponse : RestApiResponse
    {
        public AccessReviewInstanceDecisionItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync()
        {
            var p = new AccessreviewinstanceListDecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceListDecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync(AccessreviewinstanceListDecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync(AccessreviewinstanceListDecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(parameter, cancellationToken);
        }
    }
}
