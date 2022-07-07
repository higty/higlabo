using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatusOverview,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_DeviceStatusOverview: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/deviceStatusOverview";
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
    }
    public partial class IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse> IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter, IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse> IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter, IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse> IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetAsync(IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter, IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationdeviceoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse> IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetAsync(IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetParameter, IntuneDeviceconfigDeviceconfigurationdeviceoverviewGetResponse>(parameter, cancellationToken);
        }
    }
}
