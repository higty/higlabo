using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-iosvppappassignmentsettings?view=graph-rest-1.0
    /// </summary>
    public partial class IosVppAppAssignmentSettings
    {
        public bool UseDeviceLicensing { get; set; }
        public string VpnConfigurationId { get; set; }
    }
}
