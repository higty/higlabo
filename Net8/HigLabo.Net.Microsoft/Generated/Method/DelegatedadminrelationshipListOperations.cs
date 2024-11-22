using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
/// </summary>
public partial class DelegatedadminrelationshipListOperationsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DelegatedAdminRelationshipId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Operations: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/operations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Operations,
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
public partial class DelegatedadminrelationshipListOperationsResponse : RestApiResponse<DelegatedAdminRelationshipOperation>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipListOperationsResponse> DelegatedadminrelationshipListOperationsAsync()
    {
        var p = new DelegatedadminrelationshipListOperationsParameter();
        return await this.SendAsync<DelegatedadminrelationshipListOperationsParameter, DelegatedadminrelationshipListOperationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipListOperationsResponse> DelegatedadminrelationshipListOperationsAsync(CancellationToken cancellationToken)
    {
        var p = new DelegatedadminrelationshipListOperationsParameter();
        return await this.SendAsync<DelegatedadminrelationshipListOperationsParameter, DelegatedadminrelationshipListOperationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipListOperationsResponse> DelegatedadminrelationshipListOperationsAsync(DelegatedadminrelationshipListOperationsParameter parameter)
    {
        return await this.SendAsync<DelegatedadminrelationshipListOperationsParameter, DelegatedadminrelationshipListOperationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipListOperationsResponse> DelegatedadminrelationshipListOperationsAsync(DelegatedadminrelationshipListOperationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DelegatedadminrelationshipListOperationsParameter, DelegatedadminrelationshipListOperationsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-operations?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DelegatedAdminRelationshipOperation> DelegatedadminrelationshipListOperationsEnumerateAsync(DelegatedadminrelationshipListOperationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DelegatedadminrelationshipListOperationsParameter, DelegatedadminrelationshipListOperationsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DelegatedAdminRelationshipOperation>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
