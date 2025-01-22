using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewsetListDefinitionsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_AccessReviews_Definitions: return $"/identityGovernance/accessReviews/definitions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_AccessReviews_Definitions,
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
public partial class AccessReviewsetListDefinitionsResponse : RestApiResponse<AccessReviewScheduleDefinition>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewsetListDefinitionsResponse> AccessReviewsetListDefinitionsAsync()
    {
        var p = new AccessReviewsetListDefinitionsParameter();
        return await this.SendAsync<AccessReviewsetListDefinitionsParameter, AccessReviewsetListDefinitionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewsetListDefinitionsResponse> AccessReviewsetListDefinitionsAsync(CancellationToken cancellationToken)
    {
        var p = new AccessReviewsetListDefinitionsParameter();
        return await this.SendAsync<AccessReviewsetListDefinitionsParameter, AccessReviewsetListDefinitionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewsetListDefinitionsResponse> AccessReviewsetListDefinitionsAsync(AccessReviewsetListDefinitionsParameter parameter)
    {
        return await this.SendAsync<AccessReviewsetListDefinitionsParameter, AccessReviewsetListDefinitionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessReviewsetListDefinitionsResponse> AccessReviewsetListDefinitionsAsync(AccessReviewsetListDefinitionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessReviewsetListDefinitionsParameter, AccessReviewsetListDefinitionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-definitions?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessReviewScheduleDefinition> AccessReviewsetListDefinitionsEnumerateAsync(AccessReviewsetListDefinitionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessReviewsetListDefinitionsParameter, AccessReviewsetListDefinitionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessReviewScheduleDefinition>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
