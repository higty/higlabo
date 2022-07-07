using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsIosmobileappconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class IntuneAppsIosmobileappconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-iosmobileappconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class IosMobileAppConfiguration
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

        public IosMobileAppConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationListResponse> IntuneAppsIosmobileappconfigurationListAsync()
        {
            var p = new IntuneAppsIosmobileappconfigurationListParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationListParameter, IntuneAppsIosmobileappconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationListResponse> IntuneAppsIosmobileappconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsIosmobileappconfigurationListParameter();
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationListParameter, IntuneAppsIosmobileappconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationListResponse> IntuneAppsIosmobileappconfigurationListAsync(IntuneAppsIosmobileappconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationListParameter, IntuneAppsIosmobileappconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-iosmobileappconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsIosmobileappconfigurationListResponse> IntuneAppsIosmobileappconfigurationListAsync(IntuneAppsIosmobileappconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsIosmobileappconfigurationListParameter, IntuneAppsIosmobileappconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
