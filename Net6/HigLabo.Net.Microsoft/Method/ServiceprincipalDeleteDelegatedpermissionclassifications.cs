using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalDeleteDelegatedpermissionclassificationsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_DelegatedPermissionClassifications_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_DelegatedPermissionClassifications_Id: return $"/servicePrincipals/{ServicePrincipalsId}/delegatedPermissionClassifications/{DelegatedPermissionClassificationsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ServicePrincipalsId { get; set; }
        public string DelegatedPermissionClassificationsId { get; set; }
    }
    public partial class ServiceprincipalDeleteDelegatedpermissionclassificationsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync()
        {
            var p = new ServiceprincipalDeleteDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync(ServiceprincipalDeleteDelegatedpermissionclassificationsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync(ServiceprincipalDeleteDelegatedpermissionclassificationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(parameter, cancellationToken);
        }
    }
}
