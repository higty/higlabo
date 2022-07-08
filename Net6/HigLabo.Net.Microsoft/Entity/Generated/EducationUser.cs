using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationuser?view=graph-rest-1.0
    /// </summary>
    public partial class EducationUser
    {
        public enum EducationUserEducationExternalSource
        {
            Sis,
            Manual,
        }
        public enum EducationUserEducationUserRole
        {
            Student,
            Teacher,
            None,
            UnknownFutureValue,
        }

        public bool? AccountEnabled { get; set; }
        public AssignedLicense[]? AssignedLicenses { get; set; }
        public AssignedPlan[]? AssignedPlans { get; set; }
        public String[]? BusinessPhones { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Department { get; set; }
        public string? DisplayName { get; set; }
        public EducationUserEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? GivenName { get; set; }
        public string? Id { get; set; }
        public string? Mail { get; set; }
        public PhysicalAddress? MailingAddress { get; set; }
        public string? MailNickname { get; set; }
        public string? MiddleName { get; set; }
        public string? MobilePhone { get; set; }
        public EducationOnPremisesInfo? OnPremisesInfo { get; set; }
        public string? PasswordPolicies { get; set; }
        public PasswordProfile PasswordProfile { get; set; }
        public string? PreferredLanguage { get; set; }
        public EducationUserEducationUserRole PrimaryRole { get; set; }
        public ProvisionedPlan[]? ProvisionedPlans { get; set; }
        public RelatedContact[]? RelatedContacts { get; set; }
        public PhysicalAddress? ResidenceAddress { get; set; }
        public bool? ShowInAddressList { get; set; }
        public EducationStudent? Student { get; set; }
        public string? Surname { get; set; }
        public Teacher? Teacher { get; set; }
        public string? UsageLocation { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? UserType { get; set; }
        public EducationAssignment[]? Assignments { get; set; }
        public EducationClass[]? Classes { get; set; }
        public EducationSchool[]? Schools { get; set; }
        public EducationClass[]? TaughtClasses { get; set; }
        public User? User { get; set; }
        public EducationRubric[]? Rubrics { get; set; }
    }
}
