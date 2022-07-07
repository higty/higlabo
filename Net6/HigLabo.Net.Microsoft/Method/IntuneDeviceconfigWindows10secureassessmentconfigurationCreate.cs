using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationCreateAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10secureassessmentconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse> IntuneDeviceconfigWindows10secureassessmentconfigurationCreateAsync(IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10secureassessmentconfigurationCreateParameter, IntuneDeviceconfigWindows10secureassessmentconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
