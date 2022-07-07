using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81customconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81customconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81customconfigurationCreateAsync(IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81customconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81customconfigurationCreateAsync(IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81customconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81customconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
