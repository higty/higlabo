using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-wip-windowsinformationprotectionnetworklearningsummary?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionNetworkLearningSummary
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public Int32? DeviceCount { get; set; }
    }
}
