using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-wip-windowsinformationprotectionapplearningsummary?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionAppLearningSummary
    {
        public enum WindowsInformationProtectionAppLearningSummaryApplicationType
        {
            Universal,
            Desktop,
        }

        public string? Id { get; set; }
        public string? ApplicationName { get; set; }
        public ApplicationType? ApplicationType { get; set; }
        public Int32? DeviceCount { get; set; }
    }
}
