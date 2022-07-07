using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosdevicefeaturesconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class IosDeviceFeaturesConfiguration
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

        public IosDeviceFeaturesConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationListAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationListAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationListParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
