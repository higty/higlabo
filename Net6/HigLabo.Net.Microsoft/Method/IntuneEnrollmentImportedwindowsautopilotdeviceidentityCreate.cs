using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ImportedWindowsAutopilotDeviceIdentities,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ImportedWindowsAutopilotDeviceIdentities: return $"/deviceManagement/importedWindowsAutopilotDeviceIdentities";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? GroupTag { get; set; }
        public string? SerialNumber { get; set; }
        public string? ProductKey { get; set; }
        public string? ImportId { get; set; }
        public string? HardwareIdentifier { get; set; }
        public ImportedWindowsAutopilotDeviceIdentityState? State { get; set; }
        public string? AssignedUserPrincipalName { get; set; }
    }
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateAsync()
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityCreateResponse>(parameter, cancellationToken);
        }
    }
}
