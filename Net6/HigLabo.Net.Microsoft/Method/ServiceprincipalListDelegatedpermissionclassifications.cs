using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListDelegatedpermissionclassificationsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Classification,
            Id,
            PermissionId,
            PermissionName,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class ServiceprincipalListDelegatedpermissionclassificationsResponse : RestApiResponse
    {
        public DelegatedPermissionClassification[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync()
        {
            var p = new ServiceprincipalListDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync(ServiceprincipalListDelegatedpermissionclassificationsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync(ServiceprincipalListDelegatedpermissionclassificationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(parameter, cancellationToken);
        }
    }
}
