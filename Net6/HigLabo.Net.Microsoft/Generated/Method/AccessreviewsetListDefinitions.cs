using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewsetListDefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions: return $"/identityGovernance/accessReviews/definitions";
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
            StageSettings,
            Status,
            Instances,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions,
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
    public partial class AccessreviewsetListDefinitionsResponse : RestApiResponse
    {
        public AccessReviewScheduleDefinition[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync()
        {
            var p = new AccessreviewsetListDefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewsetListDefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync(AccessreviewsetListDefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListDefinitionsResponse> AccessreviewsetListDefinitionsAsync(AccessreviewsetListDefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewsetListDefinitionsParameter, AccessreviewsetListDefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
