using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListDelegatedpermissionclassificationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_DelegatedPermissionClassifications,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_DelegatedPermissionClassifications: return $"/servicePrincipals/{Id}/delegatedPermissionClassifications";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class ServiceprincipalListDelegatedpermissionclassificationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/delegatedpermissionclassification?view=graph-rest-1.0
        /// </summary>
        public partial class DelegatedPermissionClassification
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

        public DelegatedPermissionClassification[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync()
        {
            var p = new ServiceprincipalListDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListDelegatedpermissionclassificationsParameter();
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync(ServiceprincipalListDelegatedpermissionclassificationsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListDelegatedpermissionclassificationsResponse> ServiceprincipalListDelegatedpermissionclassificationsAsync(ServiceprincipalListDelegatedpermissionclassificationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListDelegatedpermissionclassificationsParameter, ServiceprincipalListDelegatedpermissionclassificationsResponse>(parameter, cancellationToken);
        }
    }
}
