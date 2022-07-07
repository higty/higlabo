using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceSettingStateSummaries_SettingStateDeviceSummaryId,
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceSettingStateSummaries_SettingStateDeviceSummaryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceSettingStateSummaries_SettingStateDeviceSummaryId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/deviceSettingStateSummaries/{SettingStateDeviceSummaryId}";
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceSettingStateSummaries_SettingStateDeviceSummaryId: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/deviceSettingStateSummaries/{SettingStateDeviceSummaryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceConfigurationId { get; set; }
        public string SettingStateDeviceSummaryId { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse> IntuneDeviceconfigSettingstatedevicesummaryDeleteAsync()
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter, IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse> IntuneDeviceconfigSettingstatedevicesummaryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter, IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse> IntuneDeviceconfigSettingstatedevicesummaryDeleteAsync(IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter, IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse> IntuneDeviceconfigSettingstatedevicesummaryDeleteAsync(IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryDeleteParameter, IntuneDeviceconfigSettingstatedevicesummaryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
