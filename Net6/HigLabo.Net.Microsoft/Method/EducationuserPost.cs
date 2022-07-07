using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserPostParameter : IRestApiParameter
    {
        public enum EducationuserPostParameterEducationExternalSource
        {
            Sis,
            Manual,
        }
        public enum EducationuserPostParameterEducationUserRole
        {
            Student,
            Teacher,
            None,
        }
        public enum ApiPath
        {
            Education_Users,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Users: return $"/education/users";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public EducationuserPostParameterEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? GivenName { get; set; }
        public string? Mail { get; set; }
        public PhysicalAddress? MailingAddress { get; set; }
        public string? MailNickname { get; set; }
        public string? MiddleName { get; set; }
        public string? MobilePhone { get; set; }
        public EducationOnPremisesInfo? OnPremisesInfo { get; set; }
        public string? PasswordPolicies { get; set; }
        public PasswordProfile PasswordProfile { get; set; }
        public string? PreferredLanguage { get; set; }
        public EducationuserPostParameterEducationUserRole PrimaryRole { get; set; }
        public ProvisionedPlan[]? ProvisionedPlans { get; set; }
        public PhysicalAddress? ResidenceAddress { get; set; }
        public EducationStudent? Student { get; set; }
        public string? Surname { get; set; }
        public Teacher? Teacher { get; set; }
        public string? UsageLocation { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? UserType { get; set; }
    }
    public partial class EducationuserPostResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostResponse> EducationuserPostAsync()
        {
            var p = new EducationuserPostParameter();
            return await this.SendAsync<EducationuserPostParameter, EducationuserPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostResponse> EducationuserPostAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserPostParameter();
            return await this.SendAsync<EducationuserPostParameter, EducationuserPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostResponse> EducationuserPostAsync(EducationuserPostParameter parameter)
        {
            return await this.SendAsync<EducationuserPostParameter, EducationuserPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserPostResponse> EducationuserPostAsync(EducationuserPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserPostParameter, EducationuserPostResponse>(parameter, cancellationToken);
        }
    }
}
