using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancepolicysettingstatesummary?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceCompliancePolicySettingStateSummary
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

        public DeviceCompliancePolicySettingStateSummary[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicysettingstatesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse> IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListAsync(IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListParameter, IntuneDeviceconfigDevicecompliancepolicysettingstatesummaryListResponse>(parameter, cancellationToken);
        }
    }
}
