using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteApproleAssignmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ServicePrincipalId { get; set; }
            public string AppRoleAssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_ServicePrincipalId_AppRoleAssignments_AppRoleAssignmentId: return $"/servicePrincipals/{ServicePrincipalId}/appRoleAssignments/{AppRoleAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_ServicePrincipalId_AppRoleAssignments_AppRoleAssignmentId,
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
    public partial class ServiceprincipalDeleteApproleAssignmentsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleAssignmentsResponse> ServiceprincipalDeleteApproleAssignmentsAsync()
        {
            var p = new ServiceprincipalDeleteApproleAssignmentsParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleAssignmentsParameter, ServiceprincipalDeleteApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleAssignmentsResponse> ServiceprincipalDeleteApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteApproleAssignmentsParameter();
            return await this.SendAsync<ServiceprincipalDeleteApproleAssignmentsParameter, ServiceprincipalDeleteApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleAssignmentsResponse> ServiceprincipalDeleteApproleAssignmentsAsync(ServiceprincipalDeleteApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleAssignmentsParameter, ServiceprincipalDeleteApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteApproleAssignmentsResponse> ServiceprincipalDeleteApproleAssignmentsAsync(ServiceprincipalDeleteApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteApproleAssignmentsParameter, ServiceprincipalDeleteApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
