using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstancedecisionitemFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions/filterByCurrentUser";
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
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_FilterByCurrentUser,
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
    public partial class AccessreviewinstancedecisionitemFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessReviewInstanceDecisionItem[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentUserResponse> AccessreviewinstancedecisionitemFilterbycurrentUserAsync()
        {
            var p = new AccessreviewinstancedecisionitemFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentUserParameter, AccessreviewinstancedecisionitemFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentUserResponse> AccessreviewinstancedecisionitemFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstancedecisionitemFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentUserParameter, AccessreviewinstancedecisionitemFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentUserResponse> AccessreviewinstancedecisionitemFilterbycurrentUserAsync(AccessreviewinstancedecisionitemFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentUserParameter, AccessreviewinstancedecisionitemFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentUserResponse> AccessreviewinstancedecisionitemFilterbycurrentUserAsync(AccessreviewinstancedecisionitemFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentUserParameter, AccessreviewinstancedecisionitemFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
