using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostApproleassignmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_AppRoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignments: return $"/servicePrincipals/{Id}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ServiceprincipalPostApproleassignmentsResponse : RestApiResponse
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
        public async Task<ServiceprincipalPostApproleassignmentsResponse> ServiceprincipalPostApproleassignmentsAsync()
        {
            var p = new ServiceprincipalPostApproleassignmentsParameter();
            return await this.SendAsync<ServiceprincipalPostApproleassignmentsParameter, ServiceprincipalPostApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignmentsResponse> ServiceprincipalPostApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostApproleassignmentsParameter();
            return await this.SendAsync<ServiceprincipalPostApproleassignmentsParameter, ServiceprincipalPostApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignmentsResponse> ServiceprincipalPostApproleassignmentsAsync(ServiceprincipalPostApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostApproleassignmentsParameter, ServiceprincipalPostApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignmentsResponse> ServiceprincipalPostApproleassignmentsAsync(ServiceprincipalPostApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostApproleassignmentsParameter, ServiceprincipalPostApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
