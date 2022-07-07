using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ImportedWindowsAutopilotDeviceIdentityId { get; set; }
    }
    public partial class IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetAsync()
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter();
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter parameter)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-enrollment-importedwindowsautopilotdeviceidentity-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse> IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetAsync(IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetParameter, IntuneEnrollmentImportedwindowsautopilotdeviceidentityGetResponse>(parameter, cancellationToken);
        }
    }
}
