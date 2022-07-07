using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter : IRestApiParameter
    {
        public enum IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameterDeviceEnrollmentType
        {
            Unknown,
            UserEnrollment,
            DeviceEnrollmentManager,
            AppleBulkWithUser,
            AppleBulkWithoutUser,
            WindowsAzureADJoin,
            WindowsBulkUserless,
            WindowsAutoEnrollment,
            WindowsBulkAzureDomainJoin,
            WindowsCoManagement,
            WindowsAzureADJoinUsingDeviceAuth,
            AppleUserEnrollment,
            AppleUserEnrollmentWithServiceAccount,
        }
        public enum IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameterDeviceEnrollmentFailureReason
        {
            Unknown,
            Authentication,
            Authorization,
            AccountValidation,
            UserValidation,
            DeviceNotSupported,
            InMaintenance,
            BadRequest,
            FeatureNotSupported,
            EnrollmentRestrictionsEnforced,
            ClientDisconnected,
            UserAbandonment,
        }
        public enum ApiPath
        {
            DeviceManagement_TroubleshootingEvents,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TroubleshootingEvents: return $"/deviceManagement/troubleshootingEvents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public string? CorrelationId { get; set; }
        public string? ManagedDeviceIdentifier { get; set; }
        public string? OperatingSystem { get; set; }
        public string? OsVersion { get; set; }
        public string? UserId { get; set; }
        public string? DeviceId { get; set; }
        public IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameterDeviceEnrollmentType EnrollmentType { get; set; }
        public IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameterDeviceEnrollmentFailureReason FailureCategory { get; set; }
        public string? FailureReason { get; set; }
    }
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse : RestApiResponse
    {
        public enum EnrollmentTroubleshootingEventDeviceEnrollmentType
        {
            Unknown,
            UserEnrollment,
            DeviceEnrollmentManager,
            AppleBulkWithUser,
            AppleBulkWithoutUser,
            WindowsAzureADJoin,
            WindowsBulkUserless,
            WindowsAutoEnrollment,
            WindowsBulkAzureDomainJoin,
            WindowsCoManagement,
            WindowsAzureADJoinUsingDeviceAuth,
            AppleUserEnrollment,
            AppleUserEnrollmentWithServiceAccount,
        }
        public enum EnrollmentTroubleshootingEventDeviceEnrollmentFailureReason
        {
            Unknown,
            Authentication,
            Authorization,
            AccountValidation,
            UserValidation,
            DeviceNotSupported,
            InMaintenance,
            BadRequest,
            FeatureNotSupported,
            EnrollmentRestrictionsEnforced,
            ClientDisconnected,
            UserAbandonment,
        }

        public string? Id { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public string? CorrelationId { get; set; }
        public string? ManagedDeviceIdentifier { get; set; }
        public string? OperatingSystem { get; set; }
        public string? OsVersion { get; set; }
        public string? UserId { get; set; }
        public string? DeviceId { get; set; }
        public DeviceEnrollmentType? EnrollmentType { get; set; }
        public DeviceEnrollmentFailureReason? FailureCategory { get; set; }
        public string? FailureReason { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventCreateAsync()
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventCreateAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventCreateAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventCreateParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventCreateResponse>(parameter, cancellationToken);
        }
    }
}
