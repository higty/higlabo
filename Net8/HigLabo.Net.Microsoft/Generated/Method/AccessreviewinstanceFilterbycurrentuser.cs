using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewinstanceFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }

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
    public partial class AccessReviewinstanceFilterbycurrentUserResponse : RestApiResponse<AccessReviewInstance>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceFilterbycurrentUserResponse> AccessReviewinstanceFilterbycurrentUserAsync()
        {
            var p = new AccessReviewinstanceFilterbycurrentUserParameter();
            return await this.SendAsync<AccessReviewinstanceFilterbycurrentUserParameter, AccessReviewinstanceFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceFilterbycurrentUserResponse> AccessReviewinstanceFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewinstanceFilterbycurrentUserParameter();
            return await this.SendAsync<AccessReviewinstanceFilterbycurrentUserParameter, AccessReviewinstanceFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceFilterbycurrentUserResponse> AccessReviewinstanceFilterbycurrentUserAsync(AccessReviewinstanceFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessReviewinstanceFilterbycurrentUserParameter, AccessReviewinstanceFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceFilterbycurrentUserResponse> AccessReviewinstanceFilterbycurrentUserAsync(AccessReviewinstanceFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewinstanceFilterbycurrentUserParameter, AccessReviewinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessReviewInstance> AccessReviewinstanceFilterbycurrentUserEnumerateAsync(AccessReviewinstanceFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessReviewinstanceFilterbycurrentUserParameter, AccessReviewinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessReviewInstance>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
