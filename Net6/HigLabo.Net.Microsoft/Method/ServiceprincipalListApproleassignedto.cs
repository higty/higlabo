using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListApproleassignedtoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class ServiceprincipalListApproleassignedtoResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/approleassignment?view=graph-rest-1.0
        /// </summary>
        public partial class AppRoleAssignment
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

        public AppRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignedtoResponse> ServiceprincipalListApproleassignedtoAsync()
        {
            var p = new ServiceprincipalListApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalListApproleassignedtoParameter, ServiceprincipalListApproleassignedtoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignedtoResponse> ServiceprincipalListApproleassignedtoAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListApproleassignedtoParameter();
            return await this.SendAsync<ServiceprincipalListApproleassignedtoParameter, ServiceprincipalListApproleassignedtoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignedtoResponse> ServiceprincipalListApproleassignedtoAsync(ServiceprincipalListApproleassignedtoParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListApproleassignedtoParameter, ServiceprincipalListApproleassignedtoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignedtoResponse> ServiceprincipalListApproleassignedtoAsync(ServiceprincipalListApproleassignedtoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListApproleassignedtoParameter, ServiceprincipalListApproleassignedtoResponse>(parameter, cancellationToken);
        }
    }
}
