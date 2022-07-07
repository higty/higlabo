using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewsetListDefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions: return $"/identityGovernance/accessReviews/definitions";
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
    public partial class AccessreviewsetListDefinitionsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync()
        {
            var p = new AccessreviewsetListDefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewsetListDefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync(AccessreviewsetListDefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync(AccessreviewsetListDefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
