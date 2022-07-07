using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidcustomconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigAndroidcustomconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-androidcustomconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class AndroidCustomConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public OmaSetting[]? OmaSettings { get; set; }
        }

        public AndroidCustomConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationListResponse> IntuneDeviceconfigAndroidcustomconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigAndroidcustomconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationListParameter, IntuneDeviceconfigAndroidcustomconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationListResponse> IntuneDeviceconfigAndroidcustomconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidcustomconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationListParameter, IntuneDeviceconfigAndroidcustomconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationListResponse> IntuneDeviceconfigAndroidcustomconfigurationListAsync(IntuneDeviceconfigAndroidcustomconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationListParameter, IntuneDeviceconfigAndroidcustomconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidcustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidcustomconfigurationListResponse> IntuneDeviceconfigAndroidcustomconfigurationListAsync(IntuneDeviceconfigAndroidcustomconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidcustomconfigurationListParameter, IntuneDeviceconfigAndroidcustomconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
