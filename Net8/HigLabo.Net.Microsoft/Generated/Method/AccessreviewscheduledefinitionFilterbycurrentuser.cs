using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewScheduleDefinitionFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_FilterByCurrentUser,
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
    public partial class AccessReviewScheduleDefinitionFilterbycurrentUserResponse : RestApiResponse<AccessReviewScheduleDefinition>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionFilterbycurrentUserResponse> AccessReviewScheduleDefinitionFilterbycurrentUserAsync()
        {
            var p = new AccessReviewScheduleDefinitionFilterbycurrentUserParameter();
            return await this.SendAsync<AccessReviewScheduleDefinitionFilterbycurrentUserParameter, AccessReviewScheduleDefinitionFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionFilterbycurrentUserResponse> AccessReviewScheduleDefinitionFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewScheduleDefinitionFilterbycurrentUserParameter();
            return await this.SendAsync<AccessReviewScheduleDefinitionFilterbycurrentUserParameter, AccessReviewScheduleDefinitionFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionFilterbycurrentUserResponse> AccessReviewScheduleDefinitionFilterbycurrentUserAsync(AccessReviewScheduleDefinitionFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessReviewScheduleDefinitionFilterbycurrentUserParameter, AccessReviewScheduleDefinitionFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionFilterbycurrentUserResponse> AccessReviewScheduleDefinitionFilterbycurrentUserAsync(AccessReviewScheduleDefinitionFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewScheduleDefinitionFilterbycurrentUserParameter, AccessReviewScheduleDefinitionFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessReviewScheduleDefinition> AccessReviewScheduleDefinitionFilterbycurrentUserEnumerateAsync(AccessReviewScheduleDefinitionFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessReviewScheduleDefinitionFilterbycurrentUserParameter, AccessReviewScheduleDefinitionFilterbycurrentUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessReviewScheduleDefinition>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
