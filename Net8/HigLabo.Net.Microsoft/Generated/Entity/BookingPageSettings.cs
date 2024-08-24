using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bookingpagesettings?view=graph-rest-1.0
    /// </summary>
    public partial class BookingPageSettings
    {
        public enum BookingPageSettingsBookingPageAccessControl
        {
            Unrestricted,
            RestrictedToOrganization,
            UnknownFutureValue,
        }

        public BookingPageSettingsBookingPageAccessControl AccessControl { get; set; }
        public string? BookingPageColorCode { get; set; }
        public string? BusinessTimeZone { get; set; }
        public string? CustomerConsentMessage { get; set; }
        public bool? EnforceOneTimePassword { get; set; }
        public bool? IsBusinessLogoDisplayEnabled { get; set; }
        public bool? IsCustomerConsentEnabled { get; set; }
        public bool? IsSearchEngineIndexabilityDisabled { get; set; }
        public bool? IsTimeSlotTimeZoneSetToBusinessTimeZone { get; set; }
        public string? PrivacyPolicyWebUrl { get; set; }
        public string? TermsAndConditionsWebUrl { get; set; }
    }
}
