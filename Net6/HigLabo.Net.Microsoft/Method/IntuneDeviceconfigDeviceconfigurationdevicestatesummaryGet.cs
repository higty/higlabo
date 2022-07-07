using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurationDeviceStateSummaries,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurationDeviceStateSummaries: return $"/deviceManagement/deviceConfigurationDeviceStateSummaries";
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
    public partial class IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse : RestApiResponse
    {
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetAsync(IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdevicestatesummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse> IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetAsync(IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetParameter, IntuneDeviceconfigDeviceconfigurationdevicestatesummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
