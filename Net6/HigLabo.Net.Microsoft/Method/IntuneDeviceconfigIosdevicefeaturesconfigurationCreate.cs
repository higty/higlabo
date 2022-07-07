using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter : IRestApiParameter
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
        public string? AssetTagTemplate { get; set; }
        public string? LockScreenFootnote { get; set; }
        public IosHomeScreenItem[]? HomeScreenDockIcons { get; set; }
        public IosHomeScreenPage[]? HomeScreenPages { get; set; }
        public IosNotificationSettings[]? NotificationSettings { get; set; }
    }
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? AssetTagTemplate { get; set; }
        public string? LockScreenFootnote { get; set; }
        public IosHomeScreenItem[]? HomeScreenDockIcons { get; set; }
        public IosHomeScreenPage[]? HomeScreenPages { get; set; }
        public IosNotificationSettings[]? NotificationSettings { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationCreateAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationCreateAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationCreateParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
