using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-macosdevicefeaturesconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class MacOSDeviceFeaturesConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
        }

        public MacOSDeviceFeaturesConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationListAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationListAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
