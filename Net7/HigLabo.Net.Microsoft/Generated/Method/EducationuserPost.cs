using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
    /// </summary>
    public partial class EducationUserPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Users: return $"/education/users";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EducationUserPostParameterEducationExternalSource
        {
            Sis,
            Manual,
        }
        public enum EducationUserPostParameterEducationUserRole
        {
            Student,
            Teacher,
            None,
        }
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
        public enum ApiPath
        {
            Education_Users,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? AccountEnabled { get; set; }
        public AssignedLicense[]? AssignedLicenses { get; set; }
        public AssignedPlan[]? AssignedPlans { get; set; }
        public String[]? BusinessPhones { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Department { get; set; }
        public string? DisplayName { get; set; }
        public EducationUserPostParameterEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? GivenName { get; set; }
        public string? Mail { get; set; }
        public PhysicalAddress? MailingAddress { get; set; }
        public string? MailNickname { get; set; }
        public string? MiddleName { get; set; }
        public string? MobilePhone { get; set; }
        public EducationOnPremisesInfo? OnPremisesInfo { get; set; }
        public string? PasswordPolicies { get; set; }
        public PasswordProfile? PasswordProfile { get; set; }
        public string? PreferredLanguage { get; set; }
        public EducationUserPostParameterEducationUserRole PrimaryRole { get; set; }
        public ProvisionedPlan[]? ProvisionedPlans { get; set; }
        public PhysicalAddress? ResidenceAddress { get; set; }
        public EducationStudent? Student { get; set; }
        public string? Surname { get; set; }
        public Teacher? Teacher { get; set; }
        public string? UsageLocation { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? UserType { get; set; }
        public string? Id { get; set; }
        public RelatedContact[]? RelatedContacts { get; set; }
        public bool? ShowInAddressList { get; set; }
        public EducationAssignment[]? Assignments { get; set; }
        public EducationClass[]? Classes { get; set; }
        public EducationSchool[]? Schools { get; set; }
        public EducationClass[]? TaughtClasses { get; set; }
        public User? User { get; set; }
        public EducationRubric[]? Rubrics { get; set; }
    }
    public partial class EducationUserPostResponse : RestApiResponse
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
        public PasswordProfile? PasswordProfile { get; set; }
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostResponse> EducationUserPostAsync()
        {
            var p = new EducationUserPostParameter();
            return await this.SendAsync<EducationUserPostParameter, EducationUserPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostResponse> EducationUserPostAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserPostParameter();
            return await this.SendAsync<EducationUserPostParameter, EducationUserPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostResponse> EducationUserPostAsync(EducationUserPostParameter parameter)
        {
            return await this.SendAsync<EducationUserPostParameter, EducationUserPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserPostResponse> EducationUserPostAsync(EducationUserPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserPostParameter, EducationUserPostResponse>(parameter, cancellationToken);
        }
    }
}
