using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoledefinitionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_RoleDefinitions_RoleDefinitionId,
            DeviceManagement_RoleDefinitions_RoleDefinitionId_RoleAssignments_RoleAssignmentId_RoleDefinition,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleDefinitions_RoleDefinitionId: return $"/deviceManagement/roleDefinitions/{RoleDefinitionId}";
                    case ApiPath.DeviceManagement_RoleDefinitions_RoleDefinitionId_RoleAssignments_RoleAssignmentId_RoleDefinition: return $"/deviceManagement/roleDefinitions/{RoleDefinitionId}/roleAssignments/{RoleAssignmentId}/roleDefinition";
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
    public partial class IntuneRbacRoledefinitionGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public RolePermission[]? RolePermissions { get; set; }
        public bool? IsBuiltIn { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionGetResponse> IntuneRbacRoledefinitionGetAsync()
        {
            var p = new IntuneRbacRoledefinitionGetParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionGetParameter, IntuneRbacRoledefinitionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionGetResponse> IntuneRbacRoledefinitionGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoledefinitionGetParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionGetParameter, IntuneRbacRoledefinitionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionGetResponse> IntuneRbacRoledefinitionGetAsync(IntuneRbacRoledefinitionGetParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionGetParameter, IntuneRbacRoledefinitionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionGetResponse> IntuneRbacRoledefinitionGetAsync(IntuneRbacRoledefinitionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionGetParameter, IntuneRbacRoledefinitionGetResponse>(parameter, cancellationToken);
        }
    }
}
