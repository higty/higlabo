using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewscheduledefinitionFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
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
            AdditionalNotificationRecipients,
            CreatedBy,
            CreatedDateTime,
            DescriptionForAdmins,
            DescriptionForReviewers,
            DisplayName,
            FallbackReviewers,
            Id,
            InstanceEnumerationScope,
            LastModifiedDateTime,
            Reviewers,
            Scope,
            Settings,
            Status,
            Instances,
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
    public partial class AccessreviewscheduledefinitionFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessReviewScheduleDefinition[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentUserResponse> AccessreviewscheduledefinitionFilterbycurrentUserAsync()
        {
            var p = new AccessreviewscheduledefinitionFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentUserParameter, AccessreviewscheduledefinitionFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentUserResponse> AccessreviewscheduledefinitionFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewscheduledefinitionFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentUserParameter, AccessreviewscheduledefinitionFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentUserResponse> AccessreviewscheduledefinitionFilterbycurrentUserAsync(AccessreviewscheduledefinitionFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentUserParameter, AccessreviewscheduledefinitionFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentUserResponse> AccessreviewscheduledefinitionFilterbycurrentUserAsync(AccessreviewscheduledefinitionFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentUserParameter, AccessreviewscheduledefinitionFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
