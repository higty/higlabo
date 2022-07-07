using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigSettingstatedevicesummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigSettingstatedevicesummaryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-settingstatedevicesummary?view=graph-rest-1.0
        /// </summary>
        public partial class SettingStateDeviceSummary
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

        public SettingStateDeviceSummary[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryListResponse> IntuneDeviceconfigSettingstatedevicesummaryListAsync()
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryListParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryListParameter, IntuneDeviceconfigSettingstatedevicesummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryListResponse> IntuneDeviceconfigSettingstatedevicesummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigSettingstatedevicesummaryListParameter();
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryListParameter, IntuneDeviceconfigSettingstatedevicesummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryListResponse> IntuneDeviceconfigSettingstatedevicesummaryListAsync(IntuneDeviceconfigSettingstatedevicesummaryListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryListParameter, IntuneDeviceconfigSettingstatedevicesummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-settingstatedevicesummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigSettingstatedevicesummaryListResponse> IntuneDeviceconfigSettingstatedevicesummaryListAsync(IntuneDeviceconfigSettingstatedevicesummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigSettingstatedevicesummaryListParameter, IntuneDeviceconfigSettingstatedevicesummaryListResponse>(parameter, cancellationToken);
        }
    }
}
