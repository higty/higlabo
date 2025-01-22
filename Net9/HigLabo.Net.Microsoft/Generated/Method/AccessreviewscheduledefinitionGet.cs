using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewScheduleDefinitionGetParameter : IRestApiParameter, IQueryParameterProperty
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
public partial class AccessReviewScheduleDefinitionGetResponse : RestApiResponse
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
    public AccessReviewStageSettings[]? StageSettings { get; set; }
    public string? Status { get; set; }
    public AccessReviewInstance[]? Instances { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionGetResponse> AccessReviewScheduleDefinitionGetAsync()
    {
        var p = new AccessReviewScheduleDefinitionGetParameter();
        return await this.SendAsync<AccessReviewScheduleDefinitionGetParameter, AccessReviewScheduleDefinitionGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionGetResponse> AccessReviewScheduleDefinitionGetAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewScheduleDefinitionGetParameter();
        return await this.SendAsync<AccessReviewScheduleDefinitionGetParameter, AccessReviewScheduleDefinitionGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionGetResponse> AccessReviewScheduleDefinitionGetAsync(AccessReviewScheduleDefinitionGetParameter parameter)
    {
        return await this.SendAsync<AccessReviewScheduleDefinitionGetParameter, AccessReviewScheduleDefinitionGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionGetResponse> AccessReviewScheduleDefinitionGetAsync(AccessReviewScheduleDefinitionGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewScheduleDefinitionGetParameter, AccessReviewScheduleDefinitionGetResponse>(parameter, cancellationToken);
    }
}
