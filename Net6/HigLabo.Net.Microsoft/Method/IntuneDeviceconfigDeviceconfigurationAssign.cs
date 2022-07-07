using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assign: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DeviceConfigurationAssignment[]? Assignments { get; set; }
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationAssignResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-deviceconfigurationassignment?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceConfigurationAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public DeviceConfigurationAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationAssignResponse> IntuneDeviceconfigDeviceconfigurationAssignAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationAssignParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationAssignParameter, IntuneDeviceconfigDeviceconfigurationAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationAssignResponse> IntuneDeviceconfigDeviceconfigurationAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationAssignParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationAssignParameter, IntuneDeviceconfigDeviceconfigurationAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationAssignResponse> IntuneDeviceconfigDeviceconfigurationAssignAsync(IntuneDeviceconfigDeviceconfigurationAssignParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationAssignParameter, IntuneDeviceconfigDeviceconfigurationAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationAssignResponse> IntuneDeviceconfigDeviceconfigurationAssignAsync(IntuneDeviceconfigDeviceconfigurationAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationAssignParameter, IntuneDeviceconfigDeviceconfigurationAssignResponse>(parameter, cancellationToken);
        }
    }
}
