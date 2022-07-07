using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceactionitemListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    }
    public partial class IntuneDeviceconfigDevicecomplianceactionitemListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecomplianceactionitem?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceComplianceActionItem
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

        public DeviceComplianceActionItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemListResponse> IntuneDeviceconfigDevicecomplianceactionitemListAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemListParameter, IntuneDeviceconfigDevicecomplianceactionitemListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemListResponse> IntuneDeviceconfigDevicecomplianceactionitemListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemListParameter, IntuneDeviceconfigDevicecomplianceactionitemListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemListResponse> IntuneDeviceconfigDevicecomplianceactionitemListAsync(IntuneDeviceconfigDevicecomplianceactionitemListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemListParameter, IntuneDeviceconfigDevicecomplianceactionitemListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemListResponse> IntuneDeviceconfigDevicecomplianceactionitemListAsync(IntuneDeviceconfigDevicecomplianceactionitemListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemListParameter, IntuneDeviceconfigDevicecomplianceactionitemListResponse>(parameter, cancellationToken);
        }
    }
}
