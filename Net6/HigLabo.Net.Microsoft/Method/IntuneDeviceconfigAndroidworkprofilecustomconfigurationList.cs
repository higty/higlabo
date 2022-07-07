using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-androidworkprofilecustomconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class AndroidWorkProfileCustomConfiguration
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public OmaSetting[]? OmaSettings { get; set; }
        }

        public AndroidWorkProfileCustomConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationListAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationListAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationListParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
