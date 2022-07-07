using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceCompliancePolicySettingStateSummaryId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
