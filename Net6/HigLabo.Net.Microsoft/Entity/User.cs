using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class User
    {
        public string AboutMe { get; set; }
        public bool AccountEnabled { get; set; }
        public AgeGroup? AgeGroup { get; set; }
        public AssignedLicense[] AssignedLicenses { get; set; }
        public AssignedPlan[] AssignedPlans { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string[] BusinessPhones { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public ConsentProvidedForMinor? ConsentProvidedForMinor { get; set; }
        public string Country { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string CreationType { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string Department { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset? EmployeeHireDate { get; set; }
        public string EmployeeId { get; set; }
        public EmployeeOrgData? EmployeeOrgData { get; set; }
        public string EmployeeType { get; set; }
        public string ExternalUserState { get; set; }
        public DateTimeOffset? ExternalUserStateChangeDateTime { get; set; }
        public string FaxNumber { get; set; }
        public string GivenName { get; set; }
        public DateTimeOffset? HireDate { get; set; }
        public string Id { get; set; }
        public ObjectIdentity[] Identities { get; set; }
        public string[] ImAddresses { get; set; }
        public string[] Interests { get; set; }
        public bool IsResourceAccount { get; set; }
        public string JobTitle { get; set; }
        public DateTimeOffset? LastPasswordChangeDateTime { get; set; }
        public LegalAgeGroupClassification? LegalAgeGroupClassification { get; set; }
        public LicenseAssignmentState[] LicenseAssignmentStates { get; set; }
        public string Mail { get; set; }
        public MailboxSettings? MailboxSettings { get; set; }
        public string MailNickname { get; set; }
        public string MobilePhone { get; set; }
        public string MySite { get; set; }
        public string OfficeLocation { get; set; }
        public string OnPremisesDistinguishedName { get; set; }
        public string OnPremisesDomainName { get; set; }
        public OnPremisesExtensionAttributes? OnPremisesExtensionAttributes { get; set; }
        public string OnPremisesImmutableId { get; set; }
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        public OnPremisesProvisioningError[] OnPremisesProvisioningErrors { get; set; }
        public string OnPremisesSamAccountName { get; set; }
        public string OnPremisesSecurityIdentifier { get; set; }
        public bool OnPremisesSyncEnabled { get; set; }
        public string OnPremisesUserPrincipalName { get; set; }
        public string[] OtherMails { get; set; }
        public string PasswordPolicies { get; set; }
        public PasswordProfile PasswordProfile { get; set; } = new PasswordProfile();
        public string[] PastProjects { get; set; }
        public string PostalCode { get; set; }
        public string PreferredDataLocation { get; set; }
        public string PreferredLanguage { get; set; }
        public string PreferredName { get; set; }
        public ProvisionedPlan[] ProvisionedPlans { get; set; }
        public string[] ProxyAddresses { get; set; }
        public DateTimeOffset? RefreshTokensValidFromDateTime { get; set; }
        public string[] Responsibilities { get; set; }
        public string[] Schools { get; set; }
        public bool ShowInAddressList { get; set; }
        public string[] Skills { get; set; }
        public DateTimeOffset? SignInSessionsValidFromDateTime { get; set; }
        public string State { get; set; }
        public string StreetAddress { get; set; }
        public string Surname { get; set; }
        public string UsageLocation { get; set; }
        public string UserPrincipalName { get; set; }
        public string UserType { get; set; }
    }
}
