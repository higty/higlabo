using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-editionupgradeconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class EditionUpgradeConfiguration
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public EditionUpgradeConfigurationEditionUpgradeLicenseType LicenseType { get; set; }
        public EditionUpgradeConfigurationWindows10EditionType TargetEdition { get; set; }
        public string License { get; set; }
        public string ProductKey { get; set; }
    }
}
