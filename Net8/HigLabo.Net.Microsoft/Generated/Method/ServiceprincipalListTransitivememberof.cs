using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListTransitiveMemberofParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_TransitiveMemberOf: return $"/servicePrincipals/{Id}/transitiveMemberOf";
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
        ServicePrincipals_Id_TransitiveMemberOf,
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
public partial class ServicePrincipalListTransitiveMemberofResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListTransitiveMemberofResponse> ServicePrincipalListTransitiveMemberofAsync()
    {
        var p = new ServicePrincipalListTransitiveMemberofParameter();
        return await this.SendAsync<ServicePrincipalListTransitiveMemberofParameter, ServicePrincipalListTransitiveMemberofResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListTransitiveMemberofResponse> ServicePrincipalListTransitiveMemberofAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListTransitiveMemberofParameter();
        return await this.SendAsync<ServicePrincipalListTransitiveMemberofParameter, ServicePrincipalListTransitiveMemberofResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListTransitiveMemberofResponse> ServicePrincipalListTransitiveMemberofAsync(ServicePrincipalListTransitiveMemberofParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListTransitiveMemberofParameter, ServicePrincipalListTransitiveMemberofResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListTransitiveMemberofResponse> ServicePrincipalListTransitiveMemberofAsync(ServicePrincipalListTransitiveMemberofParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListTransitiveMemberofParameter, ServicePrincipalListTransitiveMemberofResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> ServicePrincipalListTransitiveMemberofEnumerateAsync(ServicePrincipalListTransitiveMemberofParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListTransitiveMemberofParameter, ServicePrincipalListTransitiveMemberofResponse>(parameter, cancellationToken);
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
