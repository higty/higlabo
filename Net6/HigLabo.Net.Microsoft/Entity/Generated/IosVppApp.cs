using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-iosvppapp?view=graph-rest-1.0
    /// </summary>
    public partial class IosVppApp
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public bool IsFeatured { get; set; }
        public string PrivacyInformationUrl { get; set; }
        public string InformationUrl { get; set; }
        public string Owner { get; set; }
        public string Developer { get; set; }
        public string Notes { get; set; }
        public IosVppAppMobileAppPublishingState PublishingState { get; set; }
        public Int32? UsedLicenseCount { get; set; }
        public Int32? TotalLicenseCount { get; set; }
        public DateTimeOffset ReleaseDateTime { get; set; }
        public string AppStoreUrl { get; set; }
        public VppLicensingType? LicensingType { get; set; }
        public IosDeviceType? ApplicableDeviceType { get; set; }
        public string VppTokenOrganizationName { get; set; }
        public IosVppAppVppTokenAccountType VppTokenAccountType { get; set; }
        public string VppTokenAppleId { get; set; }
        public string BundleId { get; set; }
    }
}
