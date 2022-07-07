using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationGetAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosdevicefeaturesconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse> IntuneDeviceconfigIosdevicefeaturesconfigurationGetAsync(IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosdevicefeaturesconfigurationGetParameter, IntuneDeviceconfigIosdevicefeaturesconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
