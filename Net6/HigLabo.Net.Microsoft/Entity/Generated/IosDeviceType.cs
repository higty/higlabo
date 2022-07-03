using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-iosdevicetype?view=graph-rest-1.0
    /// </summary>
    public partial class IosDeviceType
    {
        public bool IPad { get; set; }
        public bool IPhoneAndIPod { get; set; }
    }
}
