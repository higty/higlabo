using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalPostDelegatedPermissionClassificationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_DelegatedPermissionClassifications: return $"/servicePrincipals/{Id}/delegatedPermissionClassifications";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum DelegatedPermissionClassificationPermissionClassificationType
        {
            Low,
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_DelegatedPermissionClassifications,
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
        public DelegatedPermissionClassificationPermissionClassificationType Classification { get; set; }
        public string? Id { get; set; }
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
    }
    public partial class ServicePrincipalPostDelegatedPermissionClassificationsResponse : RestApiResponse
    {
        public enum DelegatedPermissionClassificationPermissionClassificationType
        {
            Low,
        }

        public DelegatedPermissionClassificationPermissionClassificationType Classification { get; set; }
        public string? Id { get; set; }
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostDelegatedPermissionClassificationsResponse> ServicePrincipalPostDelegatedPermissionClassificationsAsync()
        {
            var p = new ServicePrincipalPostDelegatedPermissionClassificationsParameter();
            return await this.SendAsync<ServicePrincipalPostDelegatedPermissionClassificationsParameter, ServicePrincipalPostDelegatedPermissionClassificationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostDelegatedPermissionClassificationsResponse> ServicePrincipalPostDelegatedPermissionClassificationsAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalPostDelegatedPermissionClassificationsParameter();
            return await this.SendAsync<ServicePrincipalPostDelegatedPermissionClassificationsParameter, ServicePrincipalPostDelegatedPermissionClassificationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostDelegatedPermissionClassificationsResponse> ServicePrincipalPostDelegatedPermissionClassificationsAsync(ServicePrincipalPostDelegatedPermissionClassificationsParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalPostDelegatedPermissionClassificationsParameter, ServicePrincipalPostDelegatedPermissionClassificationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalPostDelegatedPermissionClassificationsResponse> ServicePrincipalPostDelegatedPermissionClassificationsAsync(ServicePrincipalPostDelegatedPermissionClassificationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalPostDelegatedPermissionClassificationsParameter, ServicePrincipalPostDelegatedPermissionClassificationsResponse>(parameter, cancellationToken);
        }
    }
}
