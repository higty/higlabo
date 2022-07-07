using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatusOverview,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCompliancePolicies_DeviceCompliancePolicyId_DeviceStatusOverview: return $"/deviceManagement/deviceCompliancePolicies/{DeviceCompliancePolicyId}/deviceStatusOverview";
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
        public string DeviceCompliancePolicyId { get; set; }
    }
    public partial class IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? PendingCount { get; set; }
        public Int32? NotApplicableCount { get; set; }
        public Int32? SuccessCount { get; set; }
        public Int32? ErrorCount { get; set; }
        public Int32? FailedCount { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public Int32? ConfigurationVersion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse> IntuneDeviceconfigDevicecompliancedeviceoverviewGetAsync()
        {
            var p = new IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter, IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse> IntuneDeviceconfigDevicecompliancedeviceoverviewGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter, IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse> IntuneDeviceconfigDevicecompliancedeviceoverviewGetAsync(IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter, IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicecompliancedeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse> IntuneDeviceconfigDevicecompliancedeviceoverviewGetAsync(IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicecompliancedeviceoverviewGetParameter, IntuneDeviceconfigDevicecompliancedeviceoverviewGetResponse>(parameter, cancellationToken);
        }
    }
}
