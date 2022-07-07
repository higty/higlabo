using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    public partial class IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-troubleshooting-enrollmenttroubleshootingevent?view=graph-rest-1.0
        /// </summary>
        public partial class EnrollmentTroubleshootingEvent
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

        public EnrollmentTroubleshootingEvent[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventListAsync()
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter();
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventListAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-enrollmenttroubleshootingevent-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse> IntuneTroubleshootingEnrollmenttroubleshootingeventListAsync(IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingEnrollmenttroubleshootingeventListParameter, IntuneTroubleshootingEnrollmenttroubleshootingeventListResponse>(parameter, cancellationToken);
        }
    }
}
