using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListOauth2PermissionGrantsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_Oauth2PermissionGrants: return $"/servicePrincipals/{Id}/oauth2PermissionGrants";
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
        ServicePrincipals_Id_Oauth2PermissionGrants,
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
public partial class ServicePrincipalListOauth2PermissionGrantsResponse : RestApiResponse<OAuth2PermissionGrant>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOauth2PermissionGrantsResponse> ServicePrincipalListOauth2PermissionGrantsAsync()
    {
        var p = new ServicePrincipalListOauth2PermissionGrantsParameter();
        return await this.SendAsync<ServicePrincipalListOauth2PermissionGrantsParameter, ServicePrincipalListOauth2PermissionGrantsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOauth2PermissionGrantsResponse> ServicePrincipalListOauth2PermissionGrantsAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListOauth2PermissionGrantsParameter();
        return await this.SendAsync<ServicePrincipalListOauth2PermissionGrantsParameter, ServicePrincipalListOauth2PermissionGrantsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOauth2PermissionGrantsResponse> ServicePrincipalListOauth2PermissionGrantsAsync(ServicePrincipalListOauth2PermissionGrantsParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListOauth2PermissionGrantsParameter, ServicePrincipalListOauth2PermissionGrantsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListOauth2PermissionGrantsResponse> ServicePrincipalListOauth2PermissionGrantsAsync(ServicePrincipalListOauth2PermissionGrantsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListOauth2PermissionGrantsParameter, ServicePrincipalListOauth2PermissionGrantsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<OAuth2PermissionGrant> ServicePrincipalListOauth2PermissionGrantsEnumerateAsync(ServicePrincipalListOauth2PermissionGrantsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListOauth2PermissionGrantsParameter, ServicePrincipalListOauth2PermissionGrantsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<OAuth2PermissionGrant>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
