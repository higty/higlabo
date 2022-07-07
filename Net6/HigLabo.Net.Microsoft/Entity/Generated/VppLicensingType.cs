using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-vpplicensingtype?view=graph-rest-1.0
    /// </summary>
    public partial class VppLicensingType
    {
        public bool? SupportsUserLicensing { get; set; }
        public bool? SupportsDeviceLicensing { get; set; }
    }
}
