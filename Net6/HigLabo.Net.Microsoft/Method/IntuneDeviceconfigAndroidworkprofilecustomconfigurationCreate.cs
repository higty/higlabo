using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter : IRestApiParameter
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
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
