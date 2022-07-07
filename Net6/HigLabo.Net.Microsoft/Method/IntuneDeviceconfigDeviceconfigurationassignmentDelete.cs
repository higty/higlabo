using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments_DeviceConfigurationAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments_DeviceConfigurationAssignmentId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/assignments/{DeviceConfigurationAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceConfigurationId { get; set; }
        public string DeviceConfigurationAssignmentId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse> IntuneDeviceconfigDeviceconfigurationassignmentDeleteAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter, IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse> IntuneDeviceconfigDeviceconfigurationassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter, IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse> IntuneDeviceconfigDeviceconfigurationassignmentDeleteAsync(IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter, IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse> IntuneDeviceconfigDeviceconfigurationassignmentDeleteAsync(IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentDeleteParameter, IntuneDeviceconfigDeviceconfigurationassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
