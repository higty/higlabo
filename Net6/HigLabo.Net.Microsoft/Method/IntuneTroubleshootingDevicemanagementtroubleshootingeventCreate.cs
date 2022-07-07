using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TroubleshootingEvents,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TroubleshootingEvents: return $"/deviceManagement/troubleshootingEvents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public string? CorrelationId { get; set; }
    }
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public string? CorrelationId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateAsync()
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventCreateResponse>(parameter, cancellationToken);
        }
    }
}
