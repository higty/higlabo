using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewscheduledefinitionFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class AccessreviewscheduledefinitionFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewscheduledefinition?view=graph-rest-1.0
        /// </summary>
        public partial class AccessReviewScheduleDefinition
        {
            public AccessReviewNotificationRecipientItem[]? AdditionalNotificationRecipients { get; set; }
            public UserIdentity? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DescriptionForAdmins { get; set; }
            public string? DescriptionForReviewers { get; set; }
            public string? DisplayName { get; set; }
            public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
            public string? Id { get; set; }
            public AccessReviewScope? InstanceEnumerationScope { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public AccessReviewReviewerScope[]? Reviewers { get; set; }
            public AccessReviewScope? Scope { get; set; }
            public AccessReviewScheduleSettings? Settings { get; set; }
            public string? Status { get; set; }
        }

        public AccessReviewScheduleDefinition[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentuserResponse> AccessreviewscheduledefinitionFilterbycurrentuserAsync()
        {
            var p = new AccessreviewscheduledefinitionFilterbycurrentuserParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentuserParameter, AccessreviewscheduledefinitionFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentuserResponse> AccessreviewscheduledefinitionFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewscheduledefinitionFilterbycurrentuserParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentuserParameter, AccessreviewscheduledefinitionFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentuserResponse> AccessreviewscheduledefinitionFilterbycurrentuserAsync(AccessreviewscheduledefinitionFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentuserParameter, AccessreviewscheduledefinitionFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionFilterbycurrentuserResponse> AccessreviewscheduledefinitionFilterbycurrentuserAsync(AccessreviewscheduledefinitionFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionFilterbycurrentuserParameter, AccessreviewscheduledefinitionFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
