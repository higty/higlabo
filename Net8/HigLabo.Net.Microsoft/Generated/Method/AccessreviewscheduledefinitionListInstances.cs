using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewScheduleDefinitionListInstancesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessReviewScheduleDefinitionId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances,
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
public partial class AccessReviewScheduleDefinitionListInstancesResponse : RestApiResponse<AccessReviewInstance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionListInstancesResponse> AccessReviewScheduleDefinitionListInstancesAsync()
    {
        var p = new AccessReviewScheduleDefinitionListInstancesParameter();
        return await this.SendAsync<AccessReviewScheduleDefinitionListInstancesParameter, AccessReviewScheduleDefinitionListInstancesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionListInstancesResponse> AccessReviewScheduleDefinitionListInstancesAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewScheduleDefinitionListInstancesParameter();
        return await this.SendAsync<AccessReviewScheduleDefinitionListInstancesParameter, AccessReviewScheduleDefinitionListInstancesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionListInstancesResponse> AccessReviewScheduleDefinitionListInstancesAsync(AccessReviewScheduleDefinitionListInstancesParameter parameter)
    {
        return await this.SendAsync<AccessReviewScheduleDefinitionListInstancesParameter, AccessReviewScheduleDefinitionListInstancesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewScheduleDefinitionListInstancesResponse> AccessReviewScheduleDefinitionListInstancesAsync(AccessReviewScheduleDefinitionListInstancesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewScheduleDefinitionListInstancesParameter, AccessReviewScheduleDefinitionListInstancesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewInstance> AccessReviewScheduleDefinitionListInstancesEnumerateAsync(AccessReviewScheduleDefinitionListInstancesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReviewScheduleDefinitionListInstancesParameter, AccessReviewScheduleDefinitionListInstancesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessReviewInstance>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
