using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewinstanceListDecisionsParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions,
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
public partial class AccessReviewinstanceListDecisionsResponse : RestApiResponse<AccessReviewInstanceDecisionItem>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListDecisionsResponse> AccessReviewinstanceListDecisionsAsync()
    {
        var p = new AccessReviewinstanceListDecisionsParameter();
        return await this.SendAsync<AccessReviewinstanceListDecisionsParameter, AccessReviewinstanceListDecisionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListDecisionsResponse> AccessReviewinstanceListDecisionsAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewinstanceListDecisionsParameter();
        return await this.SendAsync<AccessReviewinstanceListDecisionsParameter, AccessReviewinstanceListDecisionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListDecisionsResponse> AccessReviewinstanceListDecisionsAsync(AccessReviewinstanceListDecisionsParameter parameter)
    {
        return await this.SendAsync<AccessReviewinstanceListDecisionsParameter, AccessReviewinstanceListDecisionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListDecisionsResponse> AccessReviewinstanceListDecisionsAsync(AccessReviewinstanceListDecisionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewinstanceListDecisionsParameter, AccessReviewinstanceListDecisionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewInstanceDecisionItem> AccessReviewinstanceListDecisionsEnumerateAsync(AccessReviewinstanceListDecisionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReviewinstanceListDecisionsParameter, AccessReviewinstanceListDecisionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessReviewInstanceDecisionItem>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
