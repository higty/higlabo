using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule_DeviceComplianceScheduledActionForRuleId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduledActionsForRule/{DeviceComplianceScheduledActionForRuleId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicyId { get; set; }
        public string DeviceComplianceScheduledActionForRuleId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleDeleteResponse>(parameter, cancellationToken);
        }
    }
}
