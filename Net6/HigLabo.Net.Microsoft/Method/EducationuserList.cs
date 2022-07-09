using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationUserListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class EducationUserListResponse : RestApiResponse
    {
        public EducationUser[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListResponse> EducationUserListAsync()
        {
            var p = new EducationUserListParameter();
            return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListResponse> EducationUserListAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserListParameter();
            return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListResponse> EducationUserListAsync(EducationUserListParameter parameter)
        {
            return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListResponse> EducationUserListAsync(EducationUserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(parameter, cancellationToken);
        }
    }
}
