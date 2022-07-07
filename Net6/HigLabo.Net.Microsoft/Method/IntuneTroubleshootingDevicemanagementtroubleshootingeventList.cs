using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-troubleshooting-devicemanagementtroubleshootingevent?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceManagementTroubleshootingEvent
        {
            public string? Id { get; set; }
            public DateTimeOffset? EventDateTime { get; set; }
            public string? CorrelationId { get; set; }
        }

        public DeviceManagementTroubleshootingEvent[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventListAsync()
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventListAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventListAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventListParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventListResponse>(parameter, cancellationToken);
        }
    }
}
