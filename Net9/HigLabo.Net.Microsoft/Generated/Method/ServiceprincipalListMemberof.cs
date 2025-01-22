using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListMemberofParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_MemberOf: return $"/servicePrincipals/{Id}/memberOf";
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
        ServicePrincipals_Id_MemberOf,
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
public partial class ServicePrincipalListMemberofResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListMemberofResponse> ServicePrincipalListMemberofAsync()
    {
        var p = new ServicePrincipalListMemberofParameter();
        return await this.SendAsync<ServicePrincipalListMemberofParameter, ServicePrincipalListMemberofResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListMemberofResponse> ServicePrincipalListMemberofAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListMemberofParameter();
        return await this.SendAsync<ServicePrincipalListMemberofParameter, ServicePrincipalListMemberofResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListMemberofResponse> ServicePrincipalListMemberofAsync(ServicePrincipalListMemberofParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListMemberofParameter, ServicePrincipalListMemberofResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListMemberofResponse> ServicePrincipalListMemberofAsync(ServicePrincipalListMemberofParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListMemberofParameter, ServicePrincipalListMemberofResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> ServicePrincipalListMemberofEnumerateAsync(ServicePrincipalListMemberofParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListMemberofParameter, ServicePrincipalListMemberofResponse>(parameter, cancellationToken);
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
