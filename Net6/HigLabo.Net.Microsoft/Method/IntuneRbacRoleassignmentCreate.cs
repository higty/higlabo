using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoleassignmentCreateParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public String[]? ResourceScopes { get; set; }
        public string RoleDefinitionId { get; set; }
    }
    public partial class IntuneRbacRoleassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public String[]? ResourceScopes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentCreateResponse> IntuneRbacRoleassignmentCreateAsync()
        {
            var p = new IntuneRbacRoleassignmentCreateParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentCreateParameter, IntuneRbacRoleassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentCreateResponse> IntuneRbacRoleassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoleassignmentCreateParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentCreateParameter, IntuneRbacRoleassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentCreateResponse> IntuneRbacRoleassignmentCreateAsync(IntuneRbacRoleassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentCreateParameter, IntuneRbacRoleassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentCreateResponse> IntuneRbacRoleassignmentCreateAsync(IntuneRbacRoleassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentCreateParameter, IntuneRbacRoleassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
