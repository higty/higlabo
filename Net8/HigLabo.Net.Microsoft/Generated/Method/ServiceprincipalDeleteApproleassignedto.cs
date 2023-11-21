using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalDeleteApproleassignedtoParameter : IRestApiParameter
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
    public partial class ServiceprincipalDeleteApproleassignedtoResponse : RestApiResponse
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
        public async ValueTask<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync()
        {
            var p = new ServiceprincipalDeleteApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync(ServiceprincipalDeleteApproleassignedtoParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync(ServiceprincipalDeleteApproleassignedtoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(parameter, cancellationToken);
        }
    }
}
