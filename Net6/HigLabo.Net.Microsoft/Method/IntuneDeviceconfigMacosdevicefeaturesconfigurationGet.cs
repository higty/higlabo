using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}";
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
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationGetAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationGetAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
