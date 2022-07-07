using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosmobileappconfigurationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations: return $"/deviceAppManagement/mobileAppConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public String[]? TargetedMobileApps { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? EncodedSettingXml { get; set; }
        public AppConfigurationSettingItem[]? Settings { get; set; }
    }
    public partial class IntuneAppsIosmobileappconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public String[]? TargetedMobileApps { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? EncodedSettingXml { get; set; }
        public AppConfigurationSettingItem[]? Settings { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationCreateResponse> IntuneAppsIosmobileappconfigurationCreateAsync()
        {
            var p = new IntuneAppsIosmobileappconfigurationCreateParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationCreateParameter, IntuneAppsIosmobileappconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationCreateResponse> IntuneAppsIosmobileappconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosmobileappconfigurationCreateParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationCreateParameter, IntuneAppsIosmobileappconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationCreateResponse> IntuneAppsIosmobileappconfigurationCreateAsync(IntuneAppsIosmobileappconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationCreateParameter, IntuneAppsIosmobileappconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationCreateResponse> IntuneAppsIosmobileappconfigurationCreateAsync(IntuneAppsIosmobileappconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationCreateParameter, IntuneAppsIosmobileappconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
