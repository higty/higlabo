using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduleActionsForRules,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduleActionsForRules: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduleActionsForRules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DeviceComplianceScheduledActionForRule[]? DeviceComplianceScheduledActionForRules { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-scheduleactionsforrules?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse> IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter, IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-scheduleactionsforrules?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse> IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter, IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-scheduleactionsforrules?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse> IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesAsync(IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter, IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicy-scheduleactionsforrules?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse> IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesAsync(IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesParameter, IntuneDeviceconfigDevicecompliancepolicyScheduleactionsforrulesResponse>(parameter, cancellationToken);
        }
    }
}
