using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewscheduledefinitionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId,
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
    public partial class AccessreviewscheduledefinitionGetResponse : RestApiResponse
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
        public AccessReviewInstance[]? Instances { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionGetResponse> AccessreviewscheduledefinitionGetAsync()
        {
            var p = new AccessreviewscheduledefinitionGetParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionGetParameter, AccessreviewscheduledefinitionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionGetResponse> AccessreviewscheduledefinitionGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewscheduledefinitionGetParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionGetParameter, AccessreviewscheduledefinitionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionGetResponse> AccessreviewscheduledefinitionGetAsync(AccessreviewscheduledefinitionGetParameter parameter)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionGetParameter, AccessreviewscheduledefinitionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionGetResponse> AccessreviewscheduledefinitionGetAsync(AccessreviewscheduledefinitionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionGetParameter, AccessreviewscheduledefinitionGetResponse>(parameter, cancellationToken);
        }
    }
}
