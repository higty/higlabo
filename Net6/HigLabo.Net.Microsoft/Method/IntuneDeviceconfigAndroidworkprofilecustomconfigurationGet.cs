using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-androidworkprofilecustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse> IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetAsync(IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetParameter, IntuneDeviceconfigAndroidworkprofilecustomconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
