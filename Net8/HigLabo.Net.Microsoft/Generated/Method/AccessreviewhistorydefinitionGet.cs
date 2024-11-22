using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewHistoryDefinitionGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DefinitionId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions_DefinitionId: return $"/identityGovernance/accessReviews/historyDefinitions/{DefinitionId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_HistoryDefinitions_DefinitionId,
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
public partial class AccessReviewHistoryDefinitionGetResponse : RestApiResponse
{
    public enum AccessReviewHistoryDefinitionAccessReviewHistoryStatus
    {
        Done,
        InProgress,
        Error,
        Requested,
        UnknownFutureValue,
    }

    public UserIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public String[]? Decisions { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
    public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
    public AccessReviewHistoryScheduleSettings? ScheduleSettings { get; set; }
    public AccessReviewScope[]? Scopes { get; set; }
    public AccessReviewHistoryDefinitionAccessReviewHistoryStatus Status { get; set; }
    public AccessReviewHistoryInstance[]? Instances { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionGetResponse> AccessReviewHistoryDefinitionGetAsync()
    {
        var p = new AccessReviewHistoryDefinitionGetParameter();
        return await this.SendAsync<AccessReviewHistoryDefinitionGetParameter, AccessReviewHistoryDefinitionGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionGetResponse> AccessReviewHistoryDefinitionGetAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewHistoryDefinitionGetParameter();
        return await this.SendAsync<AccessReviewHistoryDefinitionGetParameter, AccessReviewHistoryDefinitionGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionGetResponse> AccessReviewHistoryDefinitionGetAsync(AccessReviewHistoryDefinitionGetParameter parameter)
    {
        return await this.SendAsync<AccessReviewHistoryDefinitionGetParameter, AccessReviewHistoryDefinitionGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionGetResponse> AccessReviewHistoryDefinitionGetAsync(AccessReviewHistoryDefinitionGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewHistoryDefinitionGetParameter, AccessReviewHistoryDefinitionGetResponse>(parameter, cancellationToken);
    }
}
