using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListApproleassignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class ServiceprincipalListApproleassignmentsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignmentsResponse> ServiceprincipalListApproleassignmentsAsync()
        {
            var p = new ServiceprincipalListApproleassignmentsParameter();
            return await this.SendAsync<ServiceprincipalListApproleassignmentsParameter, ServiceprincipalListApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignmentsResponse> ServiceprincipalListApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListApproleassignmentsParameter();
            return await this.SendAsync<ServiceprincipalListApproleassignmentsParameter, ServiceprincipalListApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignmentsResponse> ServiceprincipalListApproleassignmentsAsync(ServiceprincipalListApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListApproleassignmentsParameter, ServiceprincipalListApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleassignmentsResponse> ServiceprincipalListApproleassignmentsAsync(ServiceprincipalListApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListApproleassignmentsParameter, ServiceprincipalListApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
