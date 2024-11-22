using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewinstanceListContactedReviewersParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ContactedReviewers: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/contactedReviewers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ContactedReviewers,
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
public partial class AccessReviewinstanceListContactedReviewersResponse : RestApiResponse<AccessReviewReviewer>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListContactedReviewersResponse> AccessReviewinstanceListContactedReviewersAsync()
    {
        var p = new AccessReviewinstanceListContactedReviewersParameter();
        return await this.SendAsync<AccessReviewinstanceListContactedReviewersParameter, AccessReviewinstanceListContactedReviewersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListContactedReviewersResponse> AccessReviewinstanceListContactedReviewersAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewinstanceListContactedReviewersParameter();
        return await this.SendAsync<AccessReviewinstanceListContactedReviewersParameter, AccessReviewinstanceListContactedReviewersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListContactedReviewersResponse> AccessReviewinstanceListContactedReviewersAsync(AccessReviewinstanceListContactedReviewersParameter parameter)
    {
        return await this.SendAsync<AccessReviewinstanceListContactedReviewersParameter, AccessReviewinstanceListContactedReviewersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListContactedReviewersResponse> AccessReviewinstanceListContactedReviewersAsync(AccessReviewinstanceListContactedReviewersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewinstanceListContactedReviewersParameter, AccessReviewinstanceListContactedReviewersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewReviewer> AccessReviewinstanceListContactedReviewersEnumerateAsync(AccessReviewinstanceListContactedReviewersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReviewinstanceListContactedReviewersParameter, AccessReviewinstanceListContactedReviewersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessReviewReviewer>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
