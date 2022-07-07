using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-windowsuniversalappx?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsUniversalAppX
    {
        public enum WindowsUniversalAppXMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum WindowsUniversalAppXWindowsArchitecture
        {
            None,
            X86,
            X64,
            Arm,
            Neutral,
        }
        public enum WindowsUniversalAppXWindowsDeviceType
        {
            None,
            Desktop,
            Mobile,
            Holographic,
            Team,
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
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public WindowsArchitecture? ApplicableArchitectures { get; set; }
        public WindowsDeviceType? ApplicableDeviceTypes { get; set; }
        public string? IdentityName { get; set; }
        public string? IdentityPublisherHash { get; set; }
        public string? IdentityResourceIdentifier { get; set; }
        public bool? IsBundle { get; set; }
        public WindowsMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public string? IdentityVersion { get; set; }
    }
}
