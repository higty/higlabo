using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoleassignmentDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string RoleDefinitionId { get; set; }
        public string RoleAssignmentId { get; set; }
    }
    public partial class IntuneRbacRoleassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentDeleteResponse> IntuneRbacRoleassignmentDeleteAsync()
        {
            var p = new IntuneRbacRoleassignmentDeleteParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentDeleteParameter, IntuneRbacRoleassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentDeleteResponse> IntuneRbacRoleassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoleassignmentDeleteParameter();
            return await this.SendAsync<IntuneRbacRoleassignmentDeleteParameter, IntuneRbacRoleassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentDeleteResponse> IntuneRbacRoleassignmentDeleteAsync(IntuneRbacRoleassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentDeleteParameter, IntuneRbacRoleassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoleassignmentDeleteResponse> IntuneRbacRoleassignmentDeleteAsync(IntuneRbacRoleassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoleassignmentDeleteParameter, IntuneRbacRoleassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
