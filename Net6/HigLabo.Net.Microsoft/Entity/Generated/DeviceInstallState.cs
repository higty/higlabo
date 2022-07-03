using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-deviceinstallstate?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceInstallState
    {
        public string Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceId { get; set; }
        public DateTimeOffset LastSyncDateTime { get; set; }
        public DeviceInstallStateInstallState InstallState { get; set; }
        public string ErrorCode { get; set; }
        public string OsVersion { get; set; }
        public string OsDescription { get; set; }
        public string UserName { get; set; }
    }
}
