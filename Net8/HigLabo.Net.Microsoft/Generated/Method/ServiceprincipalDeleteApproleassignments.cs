using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalDeleteApproleAssignmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServicePrincipalId { get; set; }
            public string? AppRoleAssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_ServicePrincipalId_AppRoleAssignments_AppRoleAssignmentId: return $"/servicePrincipals/{ServicePrincipalId}/appRoleAssignments/{AppRoleAssignmentId}";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_ServicePrincipalId_AppRoleAssignments_AppRoleAssignmentId,
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
    public partial class ServicePrincipalDeleteApproleAssignmentsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteApproleAssignmentsResponse> ServicePrincipalDeleteApproleAssignmentsAsync()
        {
            var p = new ServicePrincipalDeleteApproleAssignmentsParameter();
            return await this.SendAsync<ServicePrincipalDeleteApproleAssignmentsParameter, ServicePrincipalDeleteApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteApproleAssignmentsResponse> ServicePrincipalDeleteApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalDeleteApproleAssignmentsParameter();
            return await this.SendAsync<ServicePrincipalDeleteApproleAssignmentsParameter, ServicePrincipalDeleteApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteApproleAssignmentsResponse> ServicePrincipalDeleteApproleAssignmentsAsync(ServicePrincipalDeleteApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalDeleteApproleAssignmentsParameter, ServicePrincipalDeleteApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalDeleteApproleAssignmentsResponse> ServicePrincipalDeleteApproleAssignmentsAsync(ServicePrincipalDeleteApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalDeleteApproleAssignmentsParameter, ServicePrincipalDeleteApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
