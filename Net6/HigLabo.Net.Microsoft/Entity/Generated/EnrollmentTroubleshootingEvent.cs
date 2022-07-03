using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-troubleshooting-enrollmenttroubleshootingevent?view=graph-rest-1.0
    /// </summary>
    public partial class EnrollmentTroubleshootingEvent
    {
        public string Id { get; set; }
        public DateTimeOffset EventDateTime { get; set; }
        public string CorrelationId { get; set; }
        public string ManagedDeviceIdentifier { get; set; }
        public string OperatingSystem { get; set; }
        public string OsVersion { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public EnrollmentTroubleshootingEventDeviceEnrollmentType EnrollmentType { get; set; }
        public EnrollmentTroubleshootingEventDeviceEnrollmentFailureReason FailureCategory { get; set; }
        public string FailureReason { get; set; }
    }
}
