using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceScheduledActionForRuleId { get; set; }
        public string DeviceComplianceActionItemId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse> IntuneDeviceconfigDevicecomplianceactionitemDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter, IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse> IntuneDeviceconfigDevicecomplianceactionitemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter, IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse> IntuneDeviceconfigDevicecomplianceactionitemDeleteAsync(IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter, IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecomplianceactionitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse> IntuneDeviceconfigDevicecomplianceactionitemDeleteAsync(IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecomplianceactionitemDeleteParameter, IntuneDeviceconfigDevicecomplianceactionitemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
