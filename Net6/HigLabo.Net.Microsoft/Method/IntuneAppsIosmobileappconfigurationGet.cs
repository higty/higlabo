using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosmobileappconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileAppConfigurations_ManagedDeviceMobileAppConfigurationId: return $"/deviceAppManagement/mobileAppConfigurations/{ManagedDeviceMobileAppConfigurationId}";
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
        public string ManagedDeviceMobileAppConfigurationId { get; set; }
    }
    public partial class IntuneAppsIosmobileappconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationGetResponse> IntuneAppsIosmobileappconfigurationGetAsync()
        {
            var p = new IntuneAppsIosmobileappconfigurationGetParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationGetParameter, IntuneAppsIosmobileappconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationGetResponse> IntuneAppsIosmobileappconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosmobileappconfigurationGetParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationGetParameter, IntuneAppsIosmobileappconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationGetResponse> IntuneAppsIosmobileappconfigurationGetAsync(IntuneAppsIosmobileappconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationGetParameter, IntuneAppsIosmobileappconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationGetResponse> IntuneAppsIosmobileappconfigurationGetAsync(IntuneAppsIosmobileappconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationGetParameter, IntuneAppsIosmobileappconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
