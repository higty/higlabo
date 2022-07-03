using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-iosminimumoperatingsystem?view=graph-rest-1.0
    /// </summary>
    public partial class IosMinimumOperatingSystem
    {
        public bool V8_0 { get; set; }
        public bool V9_0 { get; set; }
        public bool V10_0 { get; set; }
        public bool V11_0 { get; set; }
        public bool V12_0 { get; set; }
        public bool V13_0 { get; set; }
        public bool V14_0 { get; set; }
    }
}
