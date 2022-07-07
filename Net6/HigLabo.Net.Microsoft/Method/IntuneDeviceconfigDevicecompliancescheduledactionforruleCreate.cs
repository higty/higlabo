using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_ScheduledActionsForRule: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/scheduledActionsForRule";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? RuleName { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? RuleName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancescheduledactionforrule-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse> IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateAsync(IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateParameter, IntuneDeviceconfigDevicecompliancescheduledactionforruleCreateResponse>(parameter, cancellationToken);
        }
    }
}
