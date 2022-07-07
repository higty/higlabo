using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicySettingStateSummaries_DeviceCompliancePolicySettingStateSummaryId: return $"/deviceManagement/deviceCompliancePolicySettingStateSummaries/{DeviceCompliancePolicySettingStateSummaryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCompliancePolicySettingStateSummaryId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
