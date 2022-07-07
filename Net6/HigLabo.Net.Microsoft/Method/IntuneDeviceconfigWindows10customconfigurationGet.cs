using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10customconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10customconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationGetResponse> IntuneDeviceconfigWindows10customconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigWindows10customconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationGetParameter, IntuneDeviceconfigWindows10customconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationGetResponse> IntuneDeviceconfigWindows10customconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10customconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationGetParameter, IntuneDeviceconfigWindows10customconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationGetResponse> IntuneDeviceconfigWindows10customconfigurationGetAsync(IntuneDeviceconfigWindows10customconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationGetParameter, IntuneDeviceconfigWindows10customconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10customconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10customconfigurationGetResponse> IntuneDeviceconfigWindows10customconfigurationGetAsync(IntuneDeviceconfigWindows10customconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10customconfigurationGetParameter, IntuneDeviceconfigWindows10customconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
