using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalPostApproleassignedtoParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignedTo: return $"/servicePrincipals/{Id}/appRoleAssignedTo";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_AppRoleAssignedTo,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Guid? AppRoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrincipalDisplayName { get; set; }
        public Guid? PrincipalId { get; set; }
        public string? PrincipalType { get; set; }
        public string? ResourceDisplayName { get; set; }
        public Guid? ResourceId { get; set; }
    }
    public partial class ServicePrincipalPostApproleassignedtoResponse : RestApiResponse
    {
        public Guid? AppRoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrincipalDisplayName { get; set; }
        public Guid? PrincipalId { get; set; }
        public string? PrincipalType { get; set; }
        public string? ResourceDisplayName { get; set; }
        public Guid? ResourceId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostApproleassignedtoResponse> ServicePrincipalPostApproleassignedtoAsync()
        {
            var p = new ServicePrincipalPostApproleassignedtoParameter();
            return await this.SendAsync<ServicePrincipalPostApproleassignedtoParameter, ServicePrincipalPostApproleassignedtoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostApproleassignedtoResponse> ServicePrincipalPostApproleassignedtoAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalPostApproleassignedtoParameter();
            return await this.SendAsync<ServicePrincipalPostApproleassignedtoParameter, ServicePrincipalPostApproleassignedtoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostApproleassignedtoResponse> ServicePrincipalPostApproleassignedtoAsync(ServicePrincipalPostApproleassignedtoParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalPostApproleassignedtoParameter, ServicePrincipalPostApproleassignedtoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostApproleassignedtoResponse> ServicePrincipalPostApproleassignedtoAsync(ServicePrincipalPostApproleassignedtoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalPostApproleassignedtoParameter, ServicePrincipalPostApproleassignedtoResponse>(parameter, cancellationToken);
        }
    }
}
