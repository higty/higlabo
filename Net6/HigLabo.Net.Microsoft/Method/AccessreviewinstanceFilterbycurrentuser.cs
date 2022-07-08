using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string AccessReviewScheduleDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            EndDateTime,
            FallbackReviewers,
            Id,
            Scope,
            StartDateTime,
            Status,
            Reviewers,
            Decisions,
            ContactedReviewers,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_FilterByCurrentUser,
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
    public partial class AccessreviewinstanceFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessReviewInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentUserResponse> AccessreviewinstanceFilterbycurrentUserAsync()
        {
            var p = new AccessreviewinstanceFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentUserParameter, AccessreviewinstanceFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentUserResponse> AccessreviewinstanceFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentUserParameter, AccessreviewinstanceFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentUserResponse> AccessreviewinstanceFilterbycurrentUserAsync(AccessreviewinstanceFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentUserParameter, AccessreviewinstanceFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentUserResponse> AccessreviewinstanceFilterbycurrentUserAsync(AccessreviewinstanceFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentUserParameter, AccessreviewinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
