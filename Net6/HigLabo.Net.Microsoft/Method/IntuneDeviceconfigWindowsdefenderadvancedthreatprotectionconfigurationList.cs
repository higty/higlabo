using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
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
    public partial class IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsDefenderAdvancedThreatProtectionConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public bool? AllowSampleSharing { get; set; }
            public bool? EnableExpeditedTelemetryReporting { get; set; }
        }

        public WindowsDefenderAdvancedThreatProtectionConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListAsync(IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsdefenderadvancedthreatprotectionconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse> IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListAsync(IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListParameter, IntuneDeviceconfigWindowsdefenderadvancedthreatprotectionconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
