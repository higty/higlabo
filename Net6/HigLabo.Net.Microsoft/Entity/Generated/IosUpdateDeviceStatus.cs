using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosupdatedevicestatus?view=graph-rest-1.0
    /// </summary>
    public partial class IosUpdateDeviceStatus
    {
        public enum IosUpdateDeviceStatusIosUpdatesInstallStatus
        {
            Success,
            Available,
            Idle,
            Unknown,
            Downloading,
            DownloadFailed,
            DownloadRequiresComputer,
            DownloadInsufficientSpace,
            DownloadInsufficientPower,
            DownloadInsufficientNetwork,
            Installing,
            InstallInsufficientSpace,
            InstallInsufficientPower,
            InstallPhoneCallInProgress,
            InstallFailed,
            NotSupportedOperation,
            SharedDeviceUserLoggedInError,
            DeviceOsHigherThanDesiredOsVersion,
        }
        public enum IosUpdateDeviceStatusComplianceStatus
        {
            Unknown,
            NotApplicable,
            Compliant,
            Remediated,
            NonCompliant,
            Error,
            Conflict,
            NotAssigned,
        }

        public string? Id { get; set; }
        public IosUpdatesInstallStatus? InstallStatus { get; set; }
        public string? OsVersion { get; set; }
        public string? DeviceId { get; set; }
        public string? UserId { get; set; }
        public string? DeviceDisplayName { get; set; }
        public string? UserName { get; set; }
        public string? DeviceModel { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        public ComplianceStatus? Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
    }
}
