using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationSchoolListUsersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EducationSchoolId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_EducationSchoolId_Users: return $"/education/schools/{EducationSchoolId}/users";
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
            Education_Schools_EducationSchoolId_Users,
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
    public partial class EducationSchoolListUsersResponse : RestApiResponse
    {
        public EducationUser[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolListUsersResponse> EducationSchoolListUsersAsync()
        {
            var p = new EducationSchoolListUsersParameter();
            return await this.SendAsync<EducationSchoolListUsersParameter, EducationSchoolListUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolListUsersResponse> EducationSchoolListUsersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolListUsersParameter();
            return await this.SendAsync<EducationSchoolListUsersParameter, EducationSchoolListUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolListUsersResponse> EducationSchoolListUsersAsync(EducationSchoolListUsersParameter parameter)
        {
            return await this.SendAsync<EducationSchoolListUsersParameter, EducationSchoolListUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-list-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolListUsersResponse> EducationSchoolListUsersAsync(EducationSchoolListUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolListUsersParameter, EducationSchoolListUsersResponse>(parameter, cancellationToken);
        }
    }
}
