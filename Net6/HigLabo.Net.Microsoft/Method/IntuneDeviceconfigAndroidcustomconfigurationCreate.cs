using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidcustomconfigurationCreateParameter : IRestApiParameter
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
        public OmaSetting[]? OmaSettings { get; set; }
    }
    public partial class IntuneDeviceconfigAndroidcustomconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public OmaSetting[]? OmaSettings { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationCreateResponse> IntuneDeviceconfigAndroidcustomconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigAndroidcustomconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationCreateParameter, IntuneDeviceconfigAndroidcustomconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationCreateResponse> IntuneDeviceconfigAndroidcustomconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidcustomconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationCreateParameter, IntuneDeviceconfigAndroidcustomconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationCreateResponse> IntuneDeviceconfigAndroidcustomconfigurationCreateAsync(IntuneDeviceconfigAndroidcustomconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationCreateParameter, IntuneDeviceconfigAndroidcustomconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationCreateResponse> IntuneDeviceconfigAndroidcustomconfigurationCreateAsync(IntuneDeviceconfigAndroidcustomconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationCreateParameter, IntuneDeviceconfigAndroidcustomconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
