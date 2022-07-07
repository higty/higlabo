using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacoscustomconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigMacoscustomconfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? PayloadName { get; set; }
        public string? PayloadFileName { get; set; }
        public string? Payload { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationGetResponse> IntuneDeviceconfigMacoscustomconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigMacoscustomconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationGetParameter, IntuneDeviceconfigMacoscustomconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationGetResponse> IntuneDeviceconfigMacoscustomconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacoscustomconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationGetParameter, IntuneDeviceconfigMacoscustomconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationGetResponse> IntuneDeviceconfigMacoscustomconfigurationGetAsync(IntuneDeviceconfigMacoscustomconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationGetParameter, IntuneDeviceconfigMacoscustomconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macoscustomconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacoscustomconfigurationGetResponse> IntuneDeviceconfigMacoscustomconfigurationGetAsync(IntuneDeviceconfigMacoscustomconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacoscustomconfigurationGetParameter, IntuneDeviceconfigMacoscustomconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
