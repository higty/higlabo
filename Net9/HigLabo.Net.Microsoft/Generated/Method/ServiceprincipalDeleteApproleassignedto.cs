using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalDeleteApproleassignedtoParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? AppRoleAssignmentId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_AppRoleAssignedTo_AppRoleAssignmentId: return $"/servicePrincipals/{Id}/appRoleAssignedTo/{AppRoleAssignmentId}";
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        ServicePrincipals_Id_AppRoleAssignedTo_AppRoleAssignmentId,
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
public partial class ServicePrincipalDeleteApproleassignedtoResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteApproleassignedtoResponse> ServicePrincipalDeleteApproleassignedtoAsync()
    {
        var p = new ServicePrincipalDeleteApproleassignedtoParameter();
        return await this.SendAsync<ServicePrincipalDeleteApproleassignedtoParameter, ServicePrincipalDeleteApproleassignedtoResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteApproleassignedtoResponse> ServicePrincipalDeleteApproleassignedtoAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalDeleteApproleassignedtoParameter();
        return await this.SendAsync<ServicePrincipalDeleteApproleassignedtoParameter, ServicePrincipalDeleteApproleassignedtoResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteApproleassignedtoResponse> ServicePrincipalDeleteApproleassignedtoAsync(ServicePrincipalDeleteApproleassignedtoParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalDeleteApproleassignedtoParameter, ServicePrincipalDeleteApproleassignedtoResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalDeleteApproleassignedtoResponse> ServicePrincipalDeleteApproleassignedtoAsync(ServicePrincipalDeleteApproleassignedtoParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalDeleteApproleassignedtoParameter, ServicePrincipalDeleteApproleassignedtoResponse>(parameter, cancellationToken);
    }
}
