using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/organization?view=graph-rest-1.0
    /// </summary>
    public partial class Organization
    {
        public AssignedPlan[]? AssignedPlans { get; set; }
        public String[]? BusinessPhones { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CountryLetterCode { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsMultipleDataLocationsForServicesEnabled { get; set; }
        public String[]? MarketingNotificationEmails { get; set; }
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        public bool? OnPremisesSyncEnabled { get; set; }
        public string? PostalCode { get; set; }
        public string? PreferredLanguage { get; set; }
        public PrivacyProfile? PrivacyProfile { get; set; }
        public ProvisionedPlan[]? ProvisionedPlans { get; set; }
        public String[]? SecurityComplianceNotificationMails { get; set; }
        public String[]? SecurityComplianceNotificationPhones { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
        public String[]? TechnicalNotificationMails { get; set; }
        public VerifiedDomain[]? VerifiedDomains { get; set; }
        public CertificateBasedAuthConfiguration[]? CertificateBasedAuthConfiguration { get; set; }
        public Extension[]? Extensions { get; set; }
        public OrganizationalBranding[]? Branding { get; set; }
    }
}
