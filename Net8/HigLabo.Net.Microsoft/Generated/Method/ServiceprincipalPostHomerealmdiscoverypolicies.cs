using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalPostHomeRealmDiscoverypoliciesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_HomeRealmDiscoveryPolicies_ref: return $"/servicePrincipals/{Id}/homeRealmDiscoveryPolicies/$ref";
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        ServicePrincipals_Id_HomeRealmDiscoveryPolicies_ref,
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
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class ServicePrincipalPostHomeRealmDiscoverypoliciesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalPostHomeRealmDiscoverypoliciesResponse> ServicePrincipalPostHomeRealmDiscoverypoliciesAsync()
    {
        var p = new ServicePrincipalPostHomeRealmDiscoverypoliciesParameter();
        return await this.SendAsync<ServicePrincipalPostHomeRealmDiscoverypoliciesParameter, ServicePrincipalPostHomeRealmDiscoverypoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalPostHomeRealmDiscoverypoliciesResponse> ServicePrincipalPostHomeRealmDiscoverypoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalPostHomeRealmDiscoverypoliciesParameter();
        return await this.SendAsync<ServicePrincipalPostHomeRealmDiscoverypoliciesParameter, ServicePrincipalPostHomeRealmDiscoverypoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalPostHomeRealmDiscoverypoliciesResponse> ServicePrincipalPostHomeRealmDiscoverypoliciesAsync(ServicePrincipalPostHomeRealmDiscoverypoliciesParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalPostHomeRealmDiscoverypoliciesParameter, ServicePrincipalPostHomeRealmDiscoverypoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-homerealmdiscoverypolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalPostHomeRealmDiscoverypoliciesResponse> ServicePrincipalPostHomeRealmDiscoverypoliciesAsync(ServicePrincipalPostHomeRealmDiscoverypoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalPostHomeRealmDiscoverypoliciesParameter, ServicePrincipalPostHomeRealmDiscoverypoliciesResponse>(parameter, cancellationToken);
    }
}
