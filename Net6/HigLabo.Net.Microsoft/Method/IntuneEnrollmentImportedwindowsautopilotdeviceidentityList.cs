using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityListAsync()
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityListAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityListAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityListParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityListResponse>(parameter, cancellationToken);
        }
    }
}
