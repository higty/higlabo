using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewHistoryDefinitionListInstancesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessReviewHistoryDefinitionId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances: return $"/identityGovernance/accessReviews/historyDefinitions/{AccessReviewHistoryDefinitionId}/instances";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_HistoryDefinitions_AccessReviewHistoryDefinitionId_Instances,
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
public partial class AccessReviewHistoryDefinitionListInstancesResponse : RestApiResponse<AccessReviewHistoryInstance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionListInstancesResponse> AccessReviewHistoryDefinitionListInstancesAsync()
    {
        var p = new AccessReviewHistoryDefinitionListInstancesParameter();
        return await this.SendAsync<AccessReviewHistoryDefinitionListInstancesParameter, AccessReviewHistoryDefinitionListInstancesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionListInstancesResponse> AccessReviewHistoryDefinitionListInstancesAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewHistoryDefinitionListInstancesParameter();
        return await this.SendAsync<AccessReviewHistoryDefinitionListInstancesParameter, AccessReviewHistoryDefinitionListInstancesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionListInstancesResponse> AccessReviewHistoryDefinitionListInstancesAsync(AccessReviewHistoryDefinitionListInstancesParameter parameter)
    {
        return await this.SendAsync<AccessReviewHistoryDefinitionListInstancesParameter, AccessReviewHistoryDefinitionListInstancesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewHistoryDefinitionListInstancesResponse> AccessReviewHistoryDefinitionListInstancesAsync(AccessReviewHistoryDefinitionListInstancesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewHistoryDefinitionListInstancesParameter, AccessReviewHistoryDefinitionListInstancesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-list-instances?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewHistoryInstance> AccessReviewHistoryDefinitionListInstancesEnumerateAsync(AccessReviewHistoryDefinitionListInstancesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReviewHistoryDefinitionListInstancesParameter, AccessReviewHistoryDefinitionListInstancesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessReviewHistoryInstance>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
