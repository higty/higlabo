using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-microsoftstoreforbusinessapp?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftStoreForBusinessApp
    {
        public enum MicrosoftStoreForBusinessAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum MicrosoftStoreForBusinessAppMicrosoftStoreForBusinessLicenseType
        {
            Offline,
            Online,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public MobileAppPublishingState? PublishingState { get; set; }
        public Int32? UsedLicenseCount { get; set; }
        public Int32? TotalLicenseCount { get; set; }
        public string? ProductKey { get; set; }
        public MicrosoftStoreForBusinessLicenseType? LicenseType { get; set; }
        public string? PackageIdentityName { get; set; }
    }
}
