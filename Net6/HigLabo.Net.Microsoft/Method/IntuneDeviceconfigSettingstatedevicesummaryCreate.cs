using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSettingstatedevicesummaryCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceSettingStateSummaries,
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceSettingStateSummaries,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceSettingStateSummaries: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/deviceSettingStateSummaries";
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceSettingStateSummaries: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/deviceSettingStateSummaries";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? SettingName { get; set; }
        public string? InstancePath { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
        public string DeviceConfigurationId { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigSettingstatedevicesummaryCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? SettingName { get; set; }
        public string? InstancePath { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryCreateResponse> IntuneDeviceconfigSettingstatedevicesummaryCreateAsync()
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryCreateParameter, IntuneDeviceconfigSettingstatedevicesummaryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryCreateResponse> IntuneDeviceconfigSettingstatedevicesummaryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryCreateParameter, IntuneDeviceconfigSettingstatedevicesummaryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryCreateResponse> IntuneDeviceconfigSettingstatedevicesummaryCreateAsync(IntuneDeviceconfigSettingstatedevicesummaryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryCreateParameter, IntuneDeviceconfigSettingstatedevicesummaryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryCreateResponse> IntuneDeviceconfigSettingstatedevicesummaryCreateAsync(IntuneDeviceconfigSettingstatedevicesummaryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryCreateParameter, IntuneDeviceconfigSettingstatedevicesummaryCreateResponse>(parameter, cancellationToken);
        }
    }
}
