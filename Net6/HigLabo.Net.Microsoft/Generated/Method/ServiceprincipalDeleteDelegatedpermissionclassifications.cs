using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalDeleteDelegatedpermissionclassificationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServicePrincipalsId { get; set; }
            public string? DelegatedPermissionClassificationsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_DelegatedPermissionClassifications_Id: return $"/servicePrincipals/{ServicePrincipalsId}/delegatedPermissionClassifications/{DelegatedPermissionClassificationsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_DelegatedPermissionClassifications_Id,
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
    public partial class ServiceprincipalDeleteDelegatedpermissionclassificationsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync()
        {
            var p = new ServiceprincipalDeleteDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeleteDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync(ServiceprincipalDeleteDelegatedpermissionclassificationsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delete-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalDeleteDelegatedpermissionclassificationsResponse> ServiceprincipalDeleteDelegatedpermissionclassificationsAsync(ServiceprincipalDeleteDelegatedpermissionclassificationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeleteDelegatedpermissionclassificationsParameter, ServiceprincipalDeleteDelegatedpermissionclassificationsResponse>(parameter, cancellationToken);
        }
    }
}
