
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-troubleshooting-enrollmenttroubleshootingevent?view=graph-rest-1.0
    /// </summary>
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
}
