using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_TroubleshootingEvents_DeviceManagementTroubleshootingEventId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TroubleshootingEvents_DeviceManagementTroubleshootingEventId: return $"/deviceManagement/troubleshootingEvents/{DeviceManagementTroubleshootingEventId}";
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
        public string DeviceManagementTroubleshootingEventId { get; set; }
    }
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventGetAsync()
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventGetAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventGetAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventGetParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventGetResponse>(parameter, cancellationToken);
        }
    }
}
