using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSettingstatedevicesummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceConfigurationId { get; set; }
        public string SettingStateDeviceSummaryId { get; set; }
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigSettingstatedevicesummaryGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryGetResponse> IntuneDeviceconfigSettingstatedevicesummaryGetAsync()
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryGetParameter, IntuneDeviceconfigSettingstatedevicesummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryGetResponse> IntuneDeviceconfigSettingstatedevicesummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryGetParameter, IntuneDeviceconfigSettingstatedevicesummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryGetResponse> IntuneDeviceconfigSettingstatedevicesummaryGetAsync(IntuneDeviceconfigSettingstatedevicesummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryGetParameter, IntuneDeviceconfigSettingstatedevicesummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryGetResponse> IntuneDeviceconfigSettingstatedevicesummaryGetAsync(IntuneDeviceconfigSettingstatedevicesummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryGetParameter, IntuneDeviceconfigSettingstatedevicesummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
