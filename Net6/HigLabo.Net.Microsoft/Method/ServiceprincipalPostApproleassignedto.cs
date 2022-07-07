using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostApproleassignedtoParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_AppRoleAssignedTo,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignedTo: return $"/servicePrincipals/{Id}/appRoleAssignedTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ServiceprincipalPostApproleassignedtoResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignedtoResponse> ServiceprincipalPostApproleassignedtoAsync()
        {
            var p = new ServiceprincipalPostApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalPostApproleassignedtoParameter, ServiceprincipalPostApproleassignedtoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignedtoResponse> ServiceprincipalPostApproleassignedtoAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalPostApproleassignedtoParameter, ServiceprincipalPostApproleassignedtoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignedtoResponse> ServiceprincipalPostApproleassignedtoAsync(ServiceprincipalPostApproleassignedtoParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostApproleassignedtoParameter, ServiceprincipalPostApproleassignedtoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostApproleassignedtoResponse> ServiceprincipalPostApproleassignedtoAsync(ServiceprincipalPostApproleassignedtoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostApproleassignedtoParameter, ServiceprincipalPostApproleassignedtoResponse>(parameter, cancellationToken);
        }
    }
}
