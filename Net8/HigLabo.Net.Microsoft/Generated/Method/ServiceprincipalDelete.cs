using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id: return $"/servicePrincipals/{Id}";
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        ServicePrincipals_Id,
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
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class ServicePrincipalDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteResponse> ServicePrincipalDeleteAsync()
    {
        var p = new ServicePrincipalDeleteParameter();
        return await this.SendAsync<ServicePrincipalDeleteParameter, ServicePrincipalDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteResponse> ServicePrincipalDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalDeleteParameter();
        return await this.SendAsync<ServicePrincipalDeleteParameter, ServicePrincipalDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteResponse> ServicePrincipalDeleteAsync(ServicePrincipalDeleteParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalDeleteParameter, ServicePrincipalDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteResponse> ServicePrincipalDeleteAsync(ServicePrincipalDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalDeleteParameter, ServicePrincipalDeleteResponse>(parameter, cancellationToken);
    }
}
