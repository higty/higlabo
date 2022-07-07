using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicyDeviceStateSummary,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicyDeviceStateSummary: return $"/deviceManagement/deviceCompliancePolicyDeviceStateSummary";
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
    public partial class IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse : RestApiResponse
    {
        public Int32? InGracePeriodCount { get; set; }
        public Int32? ConfigManagerCount { get; set; }
        public string? Id { get; set; }
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicydevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicydevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicydevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetAsync(IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancepolicydevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse> IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetAsync(IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetParameter, IntuneDeviceconfigDevicecompliancepolicydevicestatesummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
