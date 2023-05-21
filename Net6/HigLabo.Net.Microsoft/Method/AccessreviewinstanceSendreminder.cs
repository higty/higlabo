using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceSendreminderParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }
            public string? AccessReviewInstanceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_SendReminder: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/sendReminder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_SendReminder,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AccessreviewinstanceSendreminderResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceSendreminderResponse> AccessreviewinstanceSendreminderAsync()
        {
            var p = new AccessreviewinstanceSendreminderParameter();
            return await this.SendAsync<AccessreviewinstanceSendreminderParameter, AccessreviewinstanceSendreminderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceSendreminderResponse> AccessreviewinstanceSendreminderAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceSendreminderParameter();
            return await this.SendAsync<AccessreviewinstanceSendreminderParameter, AccessreviewinstanceSendreminderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceSendreminderResponse> AccessreviewinstanceSendreminderAsync(AccessreviewinstanceSendreminderParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceSendreminderParameter, AccessreviewinstanceSendreminderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceSendreminderResponse> AccessreviewinstanceSendreminderAsync(AccessreviewinstanceSendreminderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceSendreminderParameter, AccessreviewinstanceSendreminderResponse>(parameter, cancellationToken);
        }
    }
}
