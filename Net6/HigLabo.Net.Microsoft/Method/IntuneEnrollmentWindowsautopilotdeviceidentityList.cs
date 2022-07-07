using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    public partial class IntuneEnrollmentWindowsautopilotdeviceidentityListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-enrollment-windowsautopilotdeviceidentity?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsAutopilotDeviceIdentity
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

        public WindowsAutopilotDeviceIdentity[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityListResponse> IntuneEnrollmentWindowsautopilotdeviceidentityListAsync()
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityListParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityListParameter, IntuneEnrollmentWindowsautopilotdeviceidentityListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityListResponse> IntuneEnrollmentWindowsautopilotdeviceidentityListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentWindowsautopilotdeviceidentityListParameter();
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityListParameter, IntuneEnrollmentWindowsautopilotdeviceidentityListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityListResponse> IntuneEnrollmentWindowsautopilotdeviceidentityListAsync(IntuneEnrollmentWindowsautopilotdeviceidentityListParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityListParameter, IntuneEnrollmentWindowsautopilotdeviceidentityListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-windowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentWindowsautopilotdeviceidentityListResponse> IntuneEnrollmentWindowsautopilotdeviceidentityListAsync(IntuneEnrollmentWindowsautopilotdeviceidentityListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentWindowsautopilotdeviceidentityListParameter, IntuneEnrollmentWindowsautopilotdeviceidentityListResponse>(parameter, cancellationToken);
        }
    }
}
