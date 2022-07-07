using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateAsync(IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigMacosdevicefeaturesconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
