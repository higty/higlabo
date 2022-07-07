using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceactionitemCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDevicecomplianceactionitemCreateParameterDeviceComplianceActionType
        {
            NoAction,
            Notification,
            Block,
            Retire,
            Wipe,
            RemoveResourceAccessProfiles,
            PushNotification,
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId_ScheduledActionConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId_ScheduledActionConfigurations: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduledActionsForRule/{DeviceComplianceScheduledActionForRuleId}/scheduledActionConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public Int32? GracePeriodHours { get; set; }
        public IntuneDeviceconfigDevicecomplianceactionitemCreateParameterDeviceComplianceActionType ActionType { get; set; }
        public string? NotificationTemplateId { get; set; }
        public String[]? NotificationMessageCCList { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceScheduledActionForRuleId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecomplianceactionitemCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemCreateResponse> IntuneDeviceconfigDevicecomplianceactionitemCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemCreateParameter, IntuneDeviceconfigDevicecomplianceactionitemCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemCreateResponse> IntuneDeviceconfigDevicecomplianceactionitemCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemCreateParameter, IntuneDeviceconfigDevicecomplianceactionitemCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemCreateResponse> IntuneDeviceconfigDevicecomplianceactionitemCreateAsync(IntuneDeviceconfigDevicecomplianceactionitemCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemCreateParameter, IntuneDeviceconfigDevicecomplianceactionitemCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemCreateResponse> IntuneDeviceconfigDevicecomplianceactionitemCreateAsync(IntuneDeviceconfigDevicecomplianceactionitemCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemCreateParameter, IntuneDeviceconfigDevicecomplianceactionitemCreateResponse>(parameter, cancellationToken);
        }
    }
}
