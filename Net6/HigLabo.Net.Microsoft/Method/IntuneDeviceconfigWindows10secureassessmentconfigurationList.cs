using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10secureassessmentconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class Windows10SecureAssessmentConfiguration
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

        public Windows10SecureAssessmentConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationListAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationListAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationListParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
