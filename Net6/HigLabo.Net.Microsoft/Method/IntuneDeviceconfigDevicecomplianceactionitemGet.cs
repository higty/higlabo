using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceactionitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId_ScheduledActionConfigurations_DeviceComplianceActionItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId_ScheduledActionConfigurations_DeviceComplianceActionItemId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduledActionsForRule/{DeviceComplianceScheduledActionForRuleId}/scheduledActionConfigurations/{DeviceComplianceActionItemId}";
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
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceScheduledActionForRuleId { get; set; }
        public string DeviceComplianceActionItemId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecomplianceactionitemGetResponse : RestApiResponse
    {
        public enum DeviceComplianceActionItemDeviceComplianceActionType
        {
            NoAction,
            Notification,
            Block,
            Retire,
            Wipe,
            RemoveResourceAccessProfiles,
            PushNotification,
        }

        public string? Id { get; set; }
        public Int32? GracePeriodHours { get; set; }
        public DeviceComplianceActionType? ActionType { get; set; }
        public string? NotificationTemplateId { get; set; }
        public String[]? NotificationMessageCCList { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemGetResponse> IntuneDeviceconfigDevicecomplianceactionitemGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemGetParameter, IntuneDeviceconfigDevicecomplianceactionitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemGetResponse> IntuneDeviceconfigDevicecomplianceactionitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemGetParameter, IntuneDeviceconfigDevicecomplianceactionitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemGetResponse> IntuneDeviceconfigDevicecomplianceactionitemGetAsync(IntuneDeviceconfigDevicecomplianceactionitemGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemGetParameter, IntuneDeviceconfigDevicecomplianceactionitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemGetResponse> IntuneDeviceconfigDevicecomplianceactionitemGetAsync(IntuneDeviceconfigDevicecomplianceactionitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemGetParameter, IntuneDeviceconfigDevicecomplianceactionitemGetResponse>(parameter, cancellationToken);
        }
    }
}
