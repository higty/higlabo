using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-configurationmanagerclientenabledfeatures?view=graph-rest-1.0
    /// </summary>
    public partial class ConfigurationManagerClientEnabledFeatures
    {
        public bool Inventory { get; set; }
        public bool ModernApps { get; set; }
        public bool ResourceAccess { get; set; }
        public bool DeviceConfiguration { get; set; }
        public bool CompliancePolicy { get; set; }
        public bool WindowsUpdateForBusiness { get; set; }
    }
}
