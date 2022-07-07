using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter : IRestApiParameter
    {
        public enum IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameterEnrollmentState
        {
            Unknown,
            Enrolled,
            PendingReset,
            Failed,
            NotContacted,
        }
        public enum ApiPath
        {
            DeviceManagement_WindowsAutopilotDeviceIdentities,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsAutopilotDeviceIdentities: return $"/deviceManagement/windowsAutopilotDeviceIdentities";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? GroupTag { get; set; }
        public string? PurchaseOrderIdentifier { get; set; }
        public string? SerialNumber { get; set; }
        public string? ProductKey { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameterEnrollmentState EnrollmentState { get; set; }
        public DateTimeOffset? LastContactedDateTime { get; set; }
        public string? AddressableUserName { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? ResourceName { get; set; }
        public string? SkuNumber { get; set; }
        public string? SystemFamily { get; set; }
        public string? AzureActiveDirectoryDeviceId { get; set; }
        public string? ManagedDeviceId { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse : RestApiResponse
    {
        public enum WindowsAutopilotDeviceIdentityEnrollmentState
        {
            Unknown,
            Enrolled,
            PendingReset,
            Failed,
            NotContacted,
        }

        public string? Id { get; set; }
        public string? GroupTag { get; set; }
        public string? PurchaseOrderIdentifier { get; set; }
        public string? SerialNumber { get; set; }
        public string? ProductKey { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public EnrollmentState? EnrollmentState { get; set; }
        public DateTimeOffset? LastContactedDateTime { get; set; }
        public string? AddressableUserName { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? ResourceName { get; set; }
        public string? SkuNumber { get; set; }
        public string? SystemFamily { get; set; }
        public string? AzureActiveDirectoryDeviceId { get; set; }
        public string? ManagedDeviceId { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentWindowsautopilotdeviceidentityCreateAsync()
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentWindowsautopilotdeviceidentityCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentWindowsautopilotdeviceidentityCreateAsync(IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse> IntuneEnrollmentWindowsautopilotdeviceidentityCreateAsync(IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityCreateParameter, IntuneEnrollmentWindowsautopilotdeviceidentityCreateResponse>(parameter, cancellationToken);
        }
    }
}
