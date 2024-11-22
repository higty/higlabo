using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewinstanceResetdecisionsParameter : IRestApiParameter
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
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ResetDecisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/resetDecisions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ResetDecisions,
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
public partial class AccessReviewinstanceResetdecisionsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceResetdecisionsResponse> AccessReviewinstanceResetdecisionsAsync()
    {
        var p = new AccessReviewinstanceResetdecisionsParameter();
        return await this.SendAsync<AccessReviewinstanceResetdecisionsParameter, AccessReviewinstanceResetdecisionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceResetdecisionsResponse> AccessReviewinstanceResetdecisionsAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewinstanceResetdecisionsParameter();
        return await this.SendAsync<AccessReviewinstanceResetdecisionsParameter, AccessReviewinstanceResetdecisionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceResetdecisionsResponse> AccessReviewinstanceResetdecisionsAsync(AccessReviewinstanceResetdecisionsParameter parameter)
    {
        return await this.SendAsync<AccessReviewinstanceResetdecisionsParameter, AccessReviewinstanceResetdecisionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceResetdecisionsResponse> AccessReviewinstanceResetdecisionsAsync(AccessReviewinstanceResetdecisionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewinstanceResetdecisionsParameter, AccessReviewinstanceResetdecisionsResponse>(parameter, cancellationToken);
    }
}
