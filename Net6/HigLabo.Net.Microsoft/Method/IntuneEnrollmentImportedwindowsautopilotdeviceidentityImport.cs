using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ImportedWindowsAutopilotDeviceIdentities_Import,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ImportedWindowsAutopilotDeviceIdentities_Import: return $"/deviceManagement/importedWindowsAutopilotDeviceIdentities/import";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ImportedWindowsAutopilotDeviceIdentity[]? ImportedWindowsAutopilotDeviceIdentities { get; set; }
    }
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-enrollment-importedwindowsautopilotdeviceidentity?view=graph-rest-1.0
        /// </summary>
        public partial class ImportedWindowsAutopilotDeviceIdentity
        {
            public string? Id { get; set; }
            public string? GroupTag { get; set; }
            public string? SerialNumber { get; set; }
            public string? ProductKey { get; set; }
            public string? ImportId { get; set; }
            public string? HardwareIdentifier { get; set; }
            public ImportedWindowsAutopilotDeviceIdentityState? State { get; set; }
            public string? AssignedUserPrincipalName { get; set; }
        }

        public ImportedWindowsAutopilotDeviceIdentity[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-import?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportAsync()
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-import?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-import?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-import?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityImportResponse>(parameter, cancellationToken);
        }
    }
}
