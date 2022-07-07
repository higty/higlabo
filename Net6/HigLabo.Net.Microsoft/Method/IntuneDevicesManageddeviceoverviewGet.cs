using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceoverviewGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_ManagedDeviceOverview,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ManagedDeviceOverview: return $"/deviceManagement/managedDeviceOverview";
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
    public partial class IntuneDevicesManageddeviceoverviewGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? EnrolledDeviceCount { get; set; }
        public Int32? MdmEnrolledCount { get; set; }
        public Int32? DualEnrolledDeviceCount { get; set; }
        public DeviceOperatingSystemSummary? DeviceOperatingSystemSummary { get; set; }
        public DeviceExchangeAccessStateSummary? DeviceExchangeAccessStateSummary { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceoverviewGetResponse> IntuneDevicesManageddeviceoverviewGetAsync()
        {
            var p = new IntuneDevicesManageddeviceoverviewGetParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceoverviewGetParameter, IntuneDevicesManageddeviceoverviewGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceoverviewGetResponse> IntuneDevicesManageddeviceoverviewGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceoverviewGetParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceoverviewGetParameter, IntuneDevicesManageddeviceoverviewGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceoverviewGetResponse> IntuneDevicesManageddeviceoverviewGetAsync(IntuneDevicesManageddeviceoverviewGetParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceoverviewGetParameter, IntuneDevicesManageddeviceoverviewGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceoverviewGetResponse> IntuneDevicesManageddeviceoverviewGetAsync(IntuneDevicesManageddeviceoverviewGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceoverviewGetParameter, IntuneDevicesManageddeviceoverviewGetResponse>(parameter, cancellationToken);
        }
    }
}
