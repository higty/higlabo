using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-update?view=graph-rest-1.0
/// </summary>
public partial class AccessReViewStageUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessReviewScheduleDefinitionId { get; set; }
        public string? AccessReviewInstanceId { get; set; }
        public string? AccessReviewStageId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/{AccessReviewStageId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public AccessReviewReviewerScope[]? Reviewers { get; set; }
    public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
}
public partial class AccessReViewStageUpdateResponse : RestApiResponse
{
    public DateTimeOffset? EndDateTime { get; set; }
    public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
    public string? Id { get; set; }
    public AccessReviewReviewerScope[]? Reviewers { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? Status { get; set; }
    public AccessReviewInstanceDecisionItem[]? Decisions { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageUpdateResponse> AccessReViewStageUpdateAsync()
    {
        var p = new AccessReViewStageUpdateParameter();
        return await this.SendAsync<AccessReViewStageUpdateParameter, AccessReViewStageUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageUpdateResponse> AccessReViewStageUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReViewStageUpdateParameter();
        return await this.SendAsync<AccessReViewStageUpdateParameter, AccessReViewStageUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageUpdateResponse> AccessReViewStageUpdateAsync(AccessReViewStageUpdateParameter parameter)
    {
        return await this.SendAsync<AccessReViewStageUpdateParameter, AccessReViewStageUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageUpdateResponse> AccessReViewStageUpdateAsync(AccessReViewStageUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReViewStageUpdateParameter, AccessReViewStageUpdateResponse>(parameter, cancellationToken);
    }
}
