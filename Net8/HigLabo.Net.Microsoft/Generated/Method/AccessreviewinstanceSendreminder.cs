using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewinstanceSendreminderParameter : IRestApiParameter
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
public partial class AccessReviewinstanceSendreminderResponse : RestApiResponse
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
    public async ValueTask<AccessReviewinstanceSendreminderResponse> AccessReviewinstanceSendreminderAsync()
    {
        var p = new AccessReviewinstanceSendreminderParameter();
        return await this.SendAsync<AccessReviewinstanceSendreminderParameter, AccessReviewinstanceSendreminderResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceSendreminderResponse> AccessReviewinstanceSendreminderAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewinstanceSendreminderParameter();
        return await this.SendAsync<AccessReviewinstanceSendreminderParameter, AccessReviewinstanceSendreminderResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceSendreminderResponse> AccessReviewinstanceSendreminderAsync(AccessReviewinstanceSendreminderParameter parameter)
    {
        return await this.SendAsync<AccessReviewinstanceSendreminderParameter, AccessReviewinstanceSendreminderResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-sendreminder?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceSendreminderResponse> AccessReviewinstanceSendreminderAsync(AccessReviewinstanceSendreminderParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewinstanceSendreminderParameter, AccessReviewinstanceSendreminderResponse>(parameter, cancellationToken);
    }
}
