using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessRootListNamedLocationsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_NamedLocations: return $"/identity/conditionalAccess/namedLocations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_ConditionalAccess_NamedLocations,
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
public partial class ConditionalAccessRootListNamedLocationsResponse : RestApiResponse<NamedLocation>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync()
    {
        var p = new ConditionalAccessRootListNamedLocationsParameter();
        return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync(CancellationToken cancellationToken)
    {
        var p = new ConditionalAccessRootListNamedLocationsParameter();
        return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync(ConditionalAccessRootListNamedLocationsParameter parameter)
    {
        return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync(ConditionalAccessRootListNamedLocationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<NamedLocation> ConditionalAccessRootListNamedLocationsEnumerateAsync(ConditionalAccessRootListNamedLocationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<NamedLocation>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
