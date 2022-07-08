using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListApproleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignments: return $"/servicePrincipals/{Id}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppRoleId,
            CreatedDateTime,
            Id,
            PrincipalDisplayName,
            PrincipalId,
            PrincipalType,
            ResourceDisplayName,
            ResourceId,
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_AppRoleAssignments,
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
    public partial class ServiceprincipalListApproleAssignmentsResponse : RestApiResponse
    {
        public AppRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleAssignmentsResponse> ServiceprincipalListApproleAssignmentsAsync()
        {
            var p = new ServiceprincipalListApproleAssignmentsParameter();
            return await this.SendAsync<ServiceprincipalListApproleAssignmentsParameter, ServiceprincipalListApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleAssignmentsResponse> ServiceprincipalListApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListApproleAssignmentsParameter();
            return await this.SendAsync<ServiceprincipalListApproleAssignmentsParameter, ServiceprincipalListApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleAssignmentsResponse> ServiceprincipalListApproleAssignmentsAsync(ServiceprincipalListApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListApproleAssignmentsParameter, ServiceprincipalListApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListApproleAssignmentsResponse> ServiceprincipalListApproleAssignmentsAsync(ServiceprincipalListApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListApproleAssignmentsParameter, ServiceprincipalListApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
