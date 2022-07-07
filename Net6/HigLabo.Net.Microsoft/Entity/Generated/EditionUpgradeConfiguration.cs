using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-editionupgradeconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class EditionUpgradeConfiguration
    {
        public enum EditionUpgradeConfigurationEditionUpgradeLicenseType
        {
            ProductKey,
            LicenseFile,
        }
        public enum EditionUpgradeConfigurationWindows10EditionType
        {
            Windows10Enterprise,
            Windows10EnterpriseN,
            Windows10Education,
            Windows10EducationN,
            Windows10MobileEnterprise,
            Windows10HolographicEnterprise,
            Windows10Professional,
            Windows10ProfessionalN,
            Windows10ProfessionalEducation,
            Windows10ProfessionalEducationN,
            Windows10ProfessionalWorkstation,
            Windows10ProfessionalWorkstationN,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public EditionUpgradeLicenseType? LicenseType { get; set; }
        public Windows10EditionType? TargetEdition { get; set; }
        public string? License { get; set; }
        public string? ProductKey { get; set; }
    }
}
