using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectioniprangecollection?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionIPRangeCollection
    {
        public string DisplayName { get; set; }
        public IpRange[] Ranges { get; set; }
    }
}
