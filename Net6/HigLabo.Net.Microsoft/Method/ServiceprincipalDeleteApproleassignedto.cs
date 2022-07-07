using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteApproleassignedtoParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_ResourceSPId_AppRoleAssignedTo_AppRoleAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_ResourceSPId_AppRoleAssignedTo_AppRoleAssignmentId: return $"/servicePrincipals/{ResourceSPId}/appRoleAssignedTo/{AppRoleAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ResourceSPId { get; set; }
        public string AppRoleAssignmentId { get; set; }
    }
    public partial class ServiceprincipalDeleteApproleassignedtoResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync()
        {
            var p = new ServiceprincipalDeleteApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync(ServiceprincipalDeleteApproleassignedtoParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignedtoResponse> ServiceprincipalDeleteApproleassignedtoAsync(ServiceprincipalDeleteApproleassignedtoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleassignedtoParameter, ServiceprincipalDeleteApproleassignedtoResponse>(parameter, cancellationToken);
        }
    }
}
