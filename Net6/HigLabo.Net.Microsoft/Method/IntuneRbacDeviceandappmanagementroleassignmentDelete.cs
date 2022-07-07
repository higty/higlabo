using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_RoleAssignments_DeviceAndAppManagementRoleAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleAssignments_DeviceAndAppManagementRoleAssignmentId: return $"/deviceManagement/roleAssignments/{DeviceAndAppManagementRoleAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceAndAppManagementRoleAssignmentId { get; set; }
    }
    public partial class IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse> IntuneRbacDeviceandappmanagementroleassignmentDeleteAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter, IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse> IntuneRbacDeviceandappmanagementroleassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter, IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse> IntuneRbacDeviceandappmanagementroleassignmentDeleteAsync(IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter, IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse> IntuneRbacDeviceandappmanagementroleassignmentDeleteAsync(IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentDeleteParameter, IntuneRbacDeviceandappmanagementroleassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
