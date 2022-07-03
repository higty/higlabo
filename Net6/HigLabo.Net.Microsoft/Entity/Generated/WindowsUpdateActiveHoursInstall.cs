using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsupdateactivehoursinstall?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsUpdateActiveHoursInstall
    {
        public TimeOnly ActiveHoursStart { get; set; }
        public TimeOnly ActiveHoursEnd { get; set; }
    }
}
