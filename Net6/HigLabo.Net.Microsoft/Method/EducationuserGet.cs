using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationUserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me: return $"/education/me";
                    case ApiPath.Education_Users_Id: return $"/education/users/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AccountEnabled,
            AssignedLicenses,
            AssignedPlans,
            BusinessPhones,
            CreatedBy,
            Department,
            DisplayName,
            ExternalSource,
            ExternalSourceDetail,
            GivenName,
            Id,
            Mail,
            MailingAddress,
            MailNickname,
            MiddleName,
            MobilePhone,
            OnPremisesInfo,
            PasswordPolicies,
            PasswordProfile,
            PreferredLanguage,
            PrimaryRole,
            ProvisionedPlans,
            RelatedContacts,
            ResidenceAddress,
            ShowInAddressList,
            Student,
            Surname,
            Teacher,
            UsageLocation,
            UserPrincipalName,
            UserType,
            Assignments,
            Classes,
            Schools,
            TaughtClasses,
            User,
            Rubrics,
        }
        public enum ApiPath
        {
            Education_Me,
            Education_Users_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class EducationUserGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserGetResponse> EducationUserGetAsync()
        {
            var p = new EducationUserGetParameter();
            return await this.SendAsync<EducationUserGetParameter, EducationUserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserGetResponse> EducationUserGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserGetParameter();
            return await this.SendAsync<EducationUserGetParameter, EducationUserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserGetResponse> EducationUserGetAsync(EducationUserGetParameter parameter)
        {
            return await this.SendAsync<EducationUserGetParameter, EducationUserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserGetResponse> EducationUserGetAsync(EducationUserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserGetParameter, EducationUserGetResponse>(parameter, cancellationToken);
        }
    }
}
