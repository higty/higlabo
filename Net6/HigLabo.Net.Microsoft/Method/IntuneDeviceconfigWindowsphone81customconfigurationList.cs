using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81customconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindowsphone81customconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsphone81customconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsPhone81CustomConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public OmaSetting[]? OmaSettings { get; set; }
        }

        public WindowsPhone81CustomConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationListResponse> IntuneDeviceconfigWindowsphone81customconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81customconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationListParameter, IntuneDeviceconfigWindowsphone81customconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationListResponse> IntuneDeviceconfigWindowsphone81customconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81customconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationListParameter, IntuneDeviceconfigWindowsphone81customconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationListResponse> IntuneDeviceconfigWindowsphone81customconfigurationListAsync(IntuneDeviceconfigWindowsphone81customconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationListParameter, IntuneDeviceconfigWindowsphone81customconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationListResponse> IntuneDeviceconfigWindowsphone81customconfigurationListAsync(IntuneDeviceconfigWindowsphone81customconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationListParameter, IntuneDeviceconfigWindowsphone81customconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
