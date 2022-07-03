using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-windowsminimumoperatingsystem?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsMinimumOperatingSystem
    {
        public bool V8_0 { get; set; }
        public bool V8_1 { get; set; }
        public bool V10_0 { get; set; }
    }
}
