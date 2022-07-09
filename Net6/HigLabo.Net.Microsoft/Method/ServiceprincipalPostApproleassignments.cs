using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostApproleAssignmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignments: return $"/servicePrincipals/{Id}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_AppRoleAssignments,
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
        public Guid? AppRoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrincipalDisplayName { get; set; }
        public Guid? PrincipalId { get; set; }
        public string? PrincipalType { get; set; }
        public string? ResourceDisplayName { get; set; }
        public Guid? ResourceId { get; set; }
    }
    public partial class ServiceprincipalPostApproleAssignmentsResponse : RestApiResponse
    {
        public Guid? AppRoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrincipalDisplayName { get; set; }
        public Guid? PrincipalId { get; set; }
        public string? PrincipalType { get; set; }
        public string? ResourceDisplayName { get; set; }
        public Guid? ResourceId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleAssignmentsResponse> ServiceprincipalPostApproleAssignmentsAsync()
        {
            var p = new ServiceprincipalPostApproleAssignmentsParameter();
            return await this.SendAsync<ServiceprincipalPostApproleAssignmentsParameter, ServiceprincipalPostApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleAssignmentsResponse> ServiceprincipalPostApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostApproleAssignmentsParameter();
            return await this.SendAsync<ServiceprincipalPostApproleAssignmentsParameter, ServiceprincipalPostApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleAssignmentsResponse> ServiceprincipalPostApproleAssignmentsAsync(ServiceprincipalPostApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostApproleAssignmentsParameter, ServiceprincipalPostApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleAssignmentsResponse> ServiceprincipalPostApproleAssignmentsAsync(ServiceprincipalPostApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostApproleAssignmentsParameter, ServiceprincipalPostApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
