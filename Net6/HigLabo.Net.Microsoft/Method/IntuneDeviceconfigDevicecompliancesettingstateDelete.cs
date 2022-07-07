using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId_DeviceComplianceSettingStates_DeviceComplianceSettingStateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId_DeviceComplianceSettingStates_DeviceComplianceSettingStateId: return $"/deviceManagement/deviceCompliancePolicySettingStateSummaries/{DeviceCompliancePolicySettingStateSummaryId}/deviceComplianceSettingStates/{DeviceComplianceSettingStateId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicySettingStateSummaryId { get; set; }
        public string DeviceComplianceSettingStateId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse> IntuneDeviceconfigDevicecompliancesettingstateDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter, IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse> IntuneDeviceconfigDevicecompliancesettingstateDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter, IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse> IntuneDeviceconfigDevicecompliancesettingstateDeleteAsync(IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter, IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancesettingstate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse> IntuneDeviceconfigDevicecompliancesettingstateDeleteAsync(IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancesettingstateDeleteParameter, IntuneDeviceconfigDevicecompliancesettingstateDeleteResponse>(parameter, cancellationToken);
        }
    }
}
