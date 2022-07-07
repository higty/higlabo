using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteApproleassignmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_ServicePrincipalId_AppRoleAssignments_AppRoleAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_ServicePrincipalId_AppRoleAssignments_AppRoleAssignmentId: return $"/servicePrincipals/{ServicePrincipalId}/appRoleAssignments/{AppRoleAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ServicePrincipalId { get; set; }
        public string AppRoleAssignmentId { get; set; }
    }
    public partial class ServiceprincipalDeleteApproleassignmentsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignmentsResponse> ServiceprincipalDeleteApproleassignmentsAsync()
        {
            var p = new ServiceprincipalDeleteApproleassignmentsParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleassignmentsParameter, ServiceprincipalDeleteApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignmentsResponse> ServiceprincipalDeleteApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteApproleassignmentsParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleassignmentsParameter, ServiceprincipalDeleteApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignmentsResponse> ServiceprincipalDeleteApproleassignmentsAsync(ServiceprincipalDeleteApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleassignmentsParameter, ServiceprincipalDeleteApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleassignmentsResponse> ServiceprincipalDeleteApproleassignmentsAsync(ServiceprincipalDeleteApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleassignmentsParameter, ServiceprincipalDeleteApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
