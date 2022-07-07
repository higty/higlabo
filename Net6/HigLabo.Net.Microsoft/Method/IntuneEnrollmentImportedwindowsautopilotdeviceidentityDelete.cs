using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ImportedWindowsAutopilotDeviceIdentities_ImportedWindowsAutopilotDeviceIdentityId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ImportedWindowsAutopilotDeviceIdentities_ImportedWindowsAutopilotDeviceIdentityId: return $"/deviceManagement/importedWindowsAutopilotDeviceIdentities/{ImportedWindowsAutopilotDeviceIdentityId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ImportedWindowsAutopilotDeviceIdentityId { get; set; }
    }
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteAsync()
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityDeleteResponse>(parameter, cancellationToken);
        }
    }
}
