using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReViewStageListDecisionsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Decisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/{AccessReviewStageId}/decisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Decisions,
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
    public partial class AccessReViewStageListDecisionsResponse : RestApiResponse<AccessReviewInstanceDecisionItem>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReViewStageListDecisionsResponse> AccessReViewStageListDecisionsAsync()
        {
            var p = new AccessReViewStageListDecisionsParameter();
            return await this.SendAsync<AccessReViewStageListDecisionsParameter, AccessReViewStageListDecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReViewStageListDecisionsResponse> AccessReViewStageListDecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReViewStageListDecisionsParameter();
            return await this.SendAsync<AccessReViewStageListDecisionsParameter, AccessReViewStageListDecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReViewStageListDecisionsResponse> AccessReViewStageListDecisionsAsync(AccessReViewStageListDecisionsParameter parameter)
        {
            return await this.SendAsync<AccessReViewStageListDecisionsParameter, AccessReViewStageListDecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReViewStageListDecisionsResponse> AccessReViewStageListDecisionsAsync(AccessReViewStageListDecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReViewStageListDecisionsParameter, AccessReViewStageListDecisionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessReviewInstanceDecisionItem> AccessReViewStageListDecisionsEnumerateAsync(AccessReViewStageListDecisionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessReViewStageListDecisionsParameter, AccessReViewStageListDecisionsResponse>(parameter, cancellationToken);
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
