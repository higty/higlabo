using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationUserDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Users_Delta: return $"/education/users/delta";
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
            Education_Users_Delta,
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
    public partial class EducationUserDeltaResponse : RestApiResponse
    {
        public EducationUser[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeltaResponse> EducationUserDeltaAsync()
        {
            var p = new EducationUserDeltaParameter();
            return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeltaResponse> EducationUserDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserDeltaParameter();
            return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeltaResponse> EducationUserDeltaAsync(EducationUserDeltaParameter parameter)
        {
            return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeltaResponse> EducationUserDeltaAsync(EducationUserDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(parameter, cancellationToken);
        }
    }
}
