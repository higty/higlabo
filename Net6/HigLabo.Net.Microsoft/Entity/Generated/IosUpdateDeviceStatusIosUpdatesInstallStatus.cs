
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosupdatedevicestatus?view=graph-rest-1.0
    /// </summary>
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
}
