using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalPostDelegatedpermissionclassificationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_DelegatedPermissionClassifications: return $"/servicePrincipals/{Id}/delegatedPermissionClassifications";
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
        public string? Id { get; set; }
        public DelegatedPermissionClassificationPermissionClassificationType Classification { get; set; }
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
    }
    public partial class ServiceprincipalPostDelegatedpermissionclassificationsResponse : RestApiResponse
    {
        public enum DelegatedPermissionClassificationPermissionClassificationType
        {
            Low,
        }

        public string? Id { get; set; }
        public DelegatedPermissionClassificationPermissionClassificationType Classification { get; set; }
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostDelegatedpermissionclassificationsResponse> ServiceprincipalPostDelegatedpermissionclassificationsAsync()
        {
            var p = new ServiceprincipalPostDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalPostDelegatedpermissionclassificationsParameter, ServiceprincipalPostDelegatedpermissionclassificationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostDelegatedpermissionclassificationsResponse> ServiceprincipalPostDelegatedpermissionclassificationsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalPostDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalPostDelegatedpermissionclassificationsParameter, ServiceprincipalPostDelegatedpermissionclassificationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostDelegatedpermissionclassificationsResponse> ServiceprincipalPostDelegatedpermissionclassificationsAsync(ServiceprincipalPostDelegatedpermissionclassificationsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalPostDelegatedpermissionclassificationsParameter, ServiceprincipalPostDelegatedpermissionclassificationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-post-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalPostDelegatedpermissionclassificationsResponse> ServiceprincipalPostDelegatedpermissionclassificationsAsync(ServiceprincipalPostDelegatedpermissionclassificationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalPostDelegatedpermissionclassificationsParameter, ServiceprincipalPostDelegatedpermissionclassificationsResponse>(parameter, cancellationToken);
        }
    }
}
