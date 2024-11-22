using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewinstanceStopParameter : IRestApiParameter
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
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stop: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stop";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stop,
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
public partial class AccessReviewinstanceStopResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceStopResponse> AccessReviewinstanceStopAsync()
    {
        var p = new AccessReviewinstanceStopParameter();
        return await this.SendAsync<AccessReviewinstanceStopParameter, AccessReviewinstanceStopResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceStopResponse> AccessReviewinstanceStopAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewinstanceStopParameter();
        return await this.SendAsync<AccessReviewinstanceStopParameter, AccessReviewinstanceStopResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceStopResponse> AccessReviewinstanceStopAsync(AccessReviewinstanceStopParameter parameter)
    {
        return await this.SendAsync<AccessReviewinstanceStopParameter, AccessReviewinstanceStopResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-stop?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceStopResponse> AccessReviewinstanceStopAsync(AccessReviewinstanceStopParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewinstanceStopParameter, AccessReviewinstanceStopResponse>(parameter, cancellationToken);
    }
}
