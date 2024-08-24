using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewinstancedecisionItemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }
            public string? AccessReviewInstanceId { get; set; }
            public string? AccessReviewInstanceDecisionItemId { get; set; }
            public string? AccessReviewStageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_AccessReviewInstanceDecisionItemId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions/{AccessReviewInstanceDecisionItemId}";
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Decisions_AccessReviewInstanceDecisionItemId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/{AccessReviewStageId}/decisions/{AccessReviewInstanceDecisionItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_AccessReviewInstanceDecisionItemId,
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Decisions_AccessReviewInstanceDecisionItemId,
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
    public partial class AccessReviewinstancedecisionItemGetResponse : RestApiResponse
    {
        public string? AccessReviewId { get; set; }
        public UserIdentity? AppliedBy { get; set; }
        public DateTimeOffset? AppliedDateTime { get; set; }
        public string? ApplyResult { get; set; }
        public string? Decision { get; set; }
        public string? Id { get; set; }
        public string? Justification { get; set; }
        public Identity? Principal { get; set; }
        public string? PrincipalLink { get; set; }
        public string? Recommendation { get; set; }
        public AccessReviewInstanceDecisionItemResource? Resource { get; set; }
        public string? ResourceLink { get; set; }
        public UserIdentity? ReviewedBy { get; set; }
        public DateTimeOffset? ReviewedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemGetResponse> AccessReviewinstancedecisionItemGetAsync()
        {
            var p = new AccessReviewinstancedecisionItemGetParameter();
            return await this.SendAsync<AccessReviewinstancedecisionItemGetParameter, AccessReviewinstancedecisionItemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemGetResponse> AccessReviewinstancedecisionItemGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewinstancedecisionItemGetParameter();
            return await this.SendAsync<AccessReviewinstancedecisionItemGetParameter, AccessReviewinstancedecisionItemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemGetResponse> AccessReviewinstancedecisionItemGetAsync(AccessReviewinstancedecisionItemGetParameter parameter)
        {
            return await this.SendAsync<AccessReviewinstancedecisionItemGetParameter, AccessReviewinstancedecisionItemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemGetResponse> AccessReviewinstancedecisionItemGetAsync(AccessReviewinstancedecisionItemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewinstancedecisionItemGetParameter, AccessReviewinstancedecisionItemGetResponse>(parameter, cancellationToken);
        }
    }
}
