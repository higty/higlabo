using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoledefinitionDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string RoleDefinitionId { get; set; }
        public string RoleAssignmentId { get; set; }
    }
    public partial class IntuneRbacRoledefinitionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionDeleteResponse> IntuneRbacRoledefinitionDeleteAsync()
        {
            var p = new IntuneRbacRoledefinitionDeleteParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionDeleteParameter, IntuneRbacRoledefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionDeleteResponse> IntuneRbacRoledefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoledefinitionDeleteParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionDeleteParameter, IntuneRbacRoledefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionDeleteResponse> IntuneRbacRoledefinitionDeleteAsync(IntuneRbacRoledefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionDeleteParameter, IntuneRbacRoledefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionDeleteResponse> IntuneRbacRoledefinitionDeleteAsync(IntuneRbacRoledefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionDeleteParameter, IntuneRbacRoledefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
