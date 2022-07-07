using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceManagementTroubleshootingEventId { get; set; }
    }
    public partial class IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public string? CorrelationId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventGetAsync()
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter();
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventGetAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-devicemanagementtroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse> IntuneTroubleshootingDevicemanagementtroubleshootingeventGetAsync(IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingDevicemanagementtroubleshootingeventGetParameter, IntuneTroubleshootingDevicemanagementtroubleshootingeventGetResponse>(parameter, cancellationToken);
        }
    }
}
