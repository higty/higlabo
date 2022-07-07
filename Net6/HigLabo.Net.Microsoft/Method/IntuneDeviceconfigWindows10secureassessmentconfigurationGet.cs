using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? LaunchUri { get; set; }
        public string? ConfigurationAccount { get; set; }
        public bool? AllowPrinting { get; set; }
        public bool? AllowScreenCapture { get; set; }
        public bool? AllowTextSuggestion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationGetAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationGetAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationGetParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
