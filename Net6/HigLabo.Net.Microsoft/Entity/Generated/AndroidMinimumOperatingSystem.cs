using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-androidminimumoperatingsystem?view=graph-rest-1.0
    /// </summary>
    public partial class AndroidMinimumOperatingSystem
    {
        public bool V4_0 { get; set; }
        public bool V4_0_3 { get; set; }
        public bool V4_1 { get; set; }
        public bool V4_2 { get; set; }
        public bool V4_3 { get; set; }
        public bool V4_4 { get; set; }
        public bool V5_0 { get; set; }
        public bool V5_1 { get; set; }
        public bool V10_0 { get; set; }
        public bool V11_0 { get; set; }
    }
}
