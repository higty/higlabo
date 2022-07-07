using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameterPolicyPlatformType
        {
            Android,
            IOS,
            MacOS,
            WindowsPhone81,
            Windows81AndLater,
            Windows10AndLater,
            AndroidWorkProfile,
            All,
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicySettingStateSummaries,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicySettingStateSummaries: return $"/deviceManagement/deviceCompliancePolicySettingStateSummaries";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Setting { get; set; }
        public string? SettingName { get; set; }
        public IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameterPolicyPlatformType PlatformType { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse : RestApiResponse
    {
        public enum DeviceCompliancePolicySettingStateSummaryPolicyPlatformType
        {
            Android,
            IOS,
            MacOS,
            WindowsPhone81,
            Windows81AndLater,
            Windows10AndLater,
            AndroidWorkProfile,
            All,
        }

        public string? Id { get; set; }
        public string? Setting { get; set; }
        public string? SettingName { get; set; }
        public PolicyPlatformType? PlatformType { get; set; }
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryCreateResponse>(parameter, cancellationToken);
        }
    }
}
