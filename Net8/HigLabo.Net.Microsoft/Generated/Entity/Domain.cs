using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/domain?view=graph-rest-1.0
    /// </summary>
    public partial class Domain
    {
        public string? AuthenticationType { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? Id { get; set; }
        public bool? IsAdminManaged { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsInitial { get; set; }
        public bool? IsRoot { get; set; }
        public bool? IsVerified { get; set; }
        public Int32? PasswordNotificationWindowInDays { get; set; }
        public Int32? PasswordValidityPeriodInDays { get; set; }
        public DomainState? State { get; set; }
        public String[]? SupportedServices { get; set; }
        public DirectoryObject[]? DomainNameReferences { get; set; }
        public DomainDnsRecord[]? ServiceConfigurationRecords { get; set; }
        public DomainDnsRecord[]? VerificationDnsRecords { get; set; }
        public InternalDomainFederation? FederationConfiguration { get; set; }
    }
}
