using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-ioshomescreenapp?view=graph-rest-1.0
    /// </summary>
    public partial class IosHomeScreenApp
    {
        public string DisplayName { get; set; }
        public string BundleID { get; set; }
    }
}
