using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListOwnedObjectsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_OwnedObjects: return $"/servicePrincipals/{Id}/ownedObjects";
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        ServicePrincipals_Id_OwnedObjects,
        ServicePrincipals,
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
public partial class ServicePrincipalListOwnedObjectsResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOwnedObjectsResponse> ServicePrincipalListOwnedObjectsAsync()
    {
        var p = new ServicePrincipalListOwnedObjectsParameter();
        return await this.SendAsync<ServicePrincipalListOwnedObjectsParameter, ServicePrincipalListOwnedObjectsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOwnedObjectsResponse> ServicePrincipalListOwnedObjectsAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListOwnedObjectsParameter();
        return await this.SendAsync<ServicePrincipalListOwnedObjectsParameter, ServicePrincipalListOwnedObjectsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOwnedObjectsResponse> ServicePrincipalListOwnedObjectsAsync(ServicePrincipalListOwnedObjectsParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListOwnedObjectsParameter, ServicePrincipalListOwnedObjectsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOwnedObjectsResponse> ServicePrincipalListOwnedObjectsAsync(ServicePrincipalListOwnedObjectsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListOwnedObjectsParameter, ServicePrincipalListOwnedObjectsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> ServicePrincipalListOwnedObjectsEnumerateAsync(ServicePrincipalListOwnedObjectsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListOwnedObjectsParameter, ServicePrincipalListOwnedObjectsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
