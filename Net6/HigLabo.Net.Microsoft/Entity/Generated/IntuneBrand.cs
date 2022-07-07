using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-intunebrand?view=graph-rest-1.0
    /// </summary>
    public partial class IntuneBrand
    {
        public string? DisplayName { get; set; }
        public RgbColor? ThemeColor { get; set; }
        public bool? ShowLogo { get; set; }
        public MimeContent? LightBackgroundLogo { get; set; }
        public MimeContent? DarkBackgroundLogo { get; set; }
        public bool? ShowNameNextToLogo { get; set; }
        public bool? ShowDisplayNameNextToLogo { get; set; }
        public string? ContactITName { get; set; }
        public string? ContactITPhoneNumber { get; set; }
        public string? ContactITEmailAddress { get; set; }
        public string? ContactITNotes { get; set; }
        public string? OnlineSupportSiteUrl { get; set; }
        public string? OnlineSupportSiteName { get; set; }
        public string? PrivacyUrl { get; set; }
    }
}
