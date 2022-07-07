using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter : IRestApiParameter
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
    public partial class IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse> IntuneRbacDeviceandappmanagementroledefinitionDeleteAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter, IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse> IntuneRbacDeviceandappmanagementroledefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter, IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse> IntuneRbacDeviceandappmanagementroledefinitionDeleteAsync(IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter, IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse> IntuneRbacDeviceandappmanagementroledefinitionDeleteAsync(IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionDeleteParameter, IntuneRbacDeviceandappmanagementroledefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
