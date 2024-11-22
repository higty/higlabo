using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class AccessReViewStageFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_FilterByCurrentUser,
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
public partial class AccessReViewStageFilterbycurrentUserResponse : RestApiResponse<AccessReviewStage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageFilterbycurrentUserResponse> AccessReViewStageFilterbycurrentUserAsync()
    {
        var p = new AccessReViewStageFilterbycurrentUserParameter();
        return await this.SendAsync<AccessReViewStageFilterbycurrentUserParameter, AccessReViewStageFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageFilterbycurrentUserResponse> AccessReViewStageFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReViewStageFilterbycurrentUserParameter();
        return await this.SendAsync<AccessReViewStageFilterbycurrentUserParameter, AccessReViewStageFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageFilterbycurrentUserResponse> AccessReViewStageFilterbycurrentUserAsync(AccessReViewStageFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<AccessReViewStageFilterbycurrentUserParameter, AccessReViewStageFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReViewStageFilterbycurrentUserResponse> AccessReViewStageFilterbycurrentUserAsync(AccessReViewStageFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReViewStageFilterbycurrentUserParameter, AccessReViewStageFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewStage> AccessReViewStageFilterbycurrentUserEnumerateAsync(AccessReViewStageFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReViewStageFilterbycurrentUserParameter, AccessReViewStageFilterbycurrentUserResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessReviewStage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
