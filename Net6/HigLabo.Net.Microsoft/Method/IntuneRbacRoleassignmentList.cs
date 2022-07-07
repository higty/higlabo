using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoleassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RoleDefinitions_RoleDefinitionId_RoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleDefinitions_RoleDefinitionId_RoleAssignments: return $"/deviceManagement/roleDefinitions/{RoleDefinitionId}/roleAssignments";
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
        public string RoleDefinitionId { get; set; }
    }
    public partial class IntuneRbacRoleassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-roleassignment?view=graph-rest-1.0
        /// </summary>
        public partial class RoleAssignment
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public String[]? ResourceScopes { get; set; }
        }

        public RoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentListResponse> IntuneRbacRoleassignmentListAsync()
        {
            var p = new IntuneRbacRoleassignmentListParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentListParameter, IntuneRbacRoleassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentListResponse> IntuneRbacRoleassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoleassignmentListParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentListParameter, IntuneRbacRoleassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentListResponse> IntuneRbacRoleassignmentListAsync(IntuneRbacRoleassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentListParameter, IntuneRbacRoleassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentListResponse> IntuneRbacRoleassignmentListAsync(IntuneRbacRoleassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentListParameter, IntuneRbacRoleassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
