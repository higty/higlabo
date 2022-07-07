using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter : IRestApiParameter
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
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteAsync()
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventDeleteResponse>(parameter, cancellationToken);
        }
    }
}
