using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewinstanceListStagesParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages,
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
public partial class AccessReviewinstanceListStagesResponse : RestApiResponse<AccessReviewStage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListStagesResponse> AccessReviewinstanceListStagesAsync()
    {
        var p = new AccessReviewinstanceListStagesParameter();
        return await this.SendAsync<AccessReviewinstanceListStagesParameter, AccessReviewinstanceListStagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListStagesResponse> AccessReviewinstanceListStagesAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewinstanceListStagesParameter();
        return await this.SendAsync<AccessReviewinstanceListStagesParameter, AccessReviewinstanceListStagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListStagesResponse> AccessReviewinstanceListStagesAsync(AccessReviewinstanceListStagesParameter parameter)
    {
        return await this.SendAsync<AccessReviewinstanceListStagesParameter, AccessReviewinstanceListStagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewinstanceListStagesResponse> AccessReviewinstanceListStagesAsync(AccessReviewinstanceListStagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewinstanceListStagesParameter, AccessReviewinstanceListStagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-list-stages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewStage> AccessReviewinstanceListStagesEnumerateAsync(AccessReviewinstanceListStagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReviewinstanceListStagesParameter, AccessReviewinstanceListStagesResponse>(parameter, cancellationToken);
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
