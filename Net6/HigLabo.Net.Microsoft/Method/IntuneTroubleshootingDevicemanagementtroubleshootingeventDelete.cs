using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TroubleshootingEvents_DeviceManagementTroubleshootingEventId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TroubleshootingEvents_DeviceManagementTroubleshootingEventId: return $"/deviceManagement/troubleshootingEvents/{DeviceManagementTroubleshootingEventId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceManagementTroubleshootingEventId { get; set; }
    }
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteAsync()
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventDeleteResponse>(parameter, cancellationToken);
        }
    }
}
