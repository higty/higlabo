using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoleassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RoleDefinitions_RoleDefinitionId_RoleAssignments_RoleAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleDefinitions_RoleDefinitionId_RoleAssignments_RoleAssignmentId: return $"/deviceManagement/roleDefinitions/{RoleDefinitionId}/roleAssignments/{RoleAssignmentId}";
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
        public string RoleAssignmentId { get; set; }
    }
    public partial class IntuneRbacRoleassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public String[]? ResourceScopes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentGetResponse> IntuneRbacRoleassignmentGetAsync()
        {
            var p = new IntuneRbacRoleassignmentGetParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentGetParameter, IntuneRbacRoleassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentGetResponse> IntuneRbacRoleassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoleassignmentGetParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentGetParameter, IntuneRbacRoleassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentGetResponse> IntuneRbacRoleassignmentGetAsync(IntuneRbacRoleassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentGetParameter, IntuneRbacRoleassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentGetResponse> IntuneRbacRoleassignmentGetAsync(IntuneRbacRoleassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentGetParameter, IntuneRbacRoleassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
