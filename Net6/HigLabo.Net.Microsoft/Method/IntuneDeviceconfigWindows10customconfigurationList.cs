using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10customconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10customconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10customconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class Windows10CustomConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public OmaSetting[]? OmaSettings { get; set; }
        }

        public Windows10CustomConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationListResponse> IntuneDeviceconfigWindows10customconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindows10customconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationListParameter, IntuneDeviceconfigWindows10customconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationListResponse> IntuneDeviceconfigWindows10customconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10customconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationListParameter, IntuneDeviceconfigWindows10customconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationListResponse> IntuneDeviceconfigWindows10customconfigurationListAsync(IntuneDeviceconfigWindows10customconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationListParameter, IntuneDeviceconfigWindows10customconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationListResponse> IntuneDeviceconfigWindows10customconfigurationListAsync(IntuneDeviceconfigWindows10customconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationListParameter, IntuneDeviceconfigWindows10customconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
