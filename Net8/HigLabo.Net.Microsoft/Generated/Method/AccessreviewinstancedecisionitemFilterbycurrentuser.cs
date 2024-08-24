using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewinstancedecisionItemFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }
            public string? AccessReviewInstanceId { get; set; }
            public string? AccessReviewStageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions/filterByCurrentUser";
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Decisions_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/{AccessReviewStageId}/decisions/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_FilterByCurrentUser,
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Decisions_FilterByCurrentUser,
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
    public partial class AccessReviewinstancedecisionItemFilterbycurrentUserResponse : RestApiResponse<AccessReviewInstanceDecisionItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemFilterbycurrentUserResponse> AccessReviewinstancedecisionItemFilterbycurrentUserAsync()
        {
            var p = new AccessReviewinstancedecisionItemFilterbycurrentUserParameter();
            return await this.SendAsync<AccessReviewinstancedecisionItemFilterbycurrentUserParameter, AccessReviewinstancedecisionItemFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemFilterbycurrentUserResponse> AccessReviewinstancedecisionItemFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewinstancedecisionItemFilterbycurrentUserParameter();
            return await this.SendAsync<AccessReviewinstancedecisionItemFilterbycurrentUserParameter, AccessReviewinstancedecisionItemFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemFilterbycurrentUserResponse> AccessReviewinstancedecisionItemFilterbycurrentUserAsync(AccessReviewinstancedecisionItemFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessReviewinstancedecisionItemFilterbycurrentUserParameter, AccessReviewinstancedecisionItemFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstancedecisionItemFilterbycurrentUserResponse> AccessReviewinstancedecisionItemFilterbycurrentUserAsync(AccessReviewinstancedecisionItemFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewinstancedecisionItemFilterbycurrentUserParameter, AccessReviewinstancedecisionItemFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessReviewInstanceDecisionItem> AccessReviewinstancedecisionItemFilterbycurrentUserEnumerateAsync(AccessReviewinstancedecisionItemFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessReviewinstancedecisionItemFilterbycurrentUserParameter, AccessReviewinstancedecisionItemFilterbycurrentUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessReviewInstanceDecisionItem>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
