
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-enrollment-windowsautopilotdeviceidentity?view=graph-rest-1.0
    /// </summary>
    public enum WindowsAutopilotDeviceIdentityEnrollmentState
    {
        Unknown,
        Enrolled,
        PendingReset,
        Failed,
        NotContacted,
    }
}
