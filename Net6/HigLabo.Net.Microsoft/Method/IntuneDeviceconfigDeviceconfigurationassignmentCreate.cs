using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse> IntuneDeviceconfigDeviceconfigurationassignmentCreateAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter, IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse> IntuneDeviceconfigDeviceconfigurationassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter, IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse> IntuneDeviceconfigDeviceconfigurationassignmentCreateAsync(IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter, IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse> IntuneDeviceconfigDeviceconfigurationassignmentCreateAsync(IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentCreateParameter, IntuneDeviceconfigDeviceconfigurationassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
