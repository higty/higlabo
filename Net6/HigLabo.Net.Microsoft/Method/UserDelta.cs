using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_Delta: return $"/users/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AboutMe,
            AccountEnabled,
            AgeGroup,
            AssignedLicenses,
            AssignedPlans,
            Birthday,
            BusinessPhones,
            City,
            CompanyName,
            ConsentProvidedForMinor,
            Country,
            CreatedDateTime,
            CreationType,
            DeletedDateTime,
            Department,
            DisplayName,
            EmployeeHireDate,
            EmployeeId,
            EmployeeOrgData,
            EmployeeType,
            ExternalUserState,
            ExternalUserStateChangeDateTime,
            FaxNumber,
            GivenName,
            HireDate,
            Id,
            Identities,
            ImAddresses,
            Interests,
            IsResourceAccount,
            JobTitle,
            LastPasswordChangeDateTime,
            LegalAgeGroupClassification,
            LicenseAssignmentStates,
            Mail,
            MailboxSettings,
            MailNickname,
            MobilePhone,
            MySite,
            OfficeLocation,
            OnPremisesDistinguishedName,
            OnPremisesDomainName,
            OnPremisesExtensionAttributes,
            OnPremisesImmutableId,
            OnPremisesLastSyncDateTime,
            OnPremisesProvisioningErrors,
            OnPremisesSamAccountName,
            OnPremisesSecurityIdentifier,
            OnPremisesSyncEnabled,
            OnPremisesUserPrincipalName,
            OtherMails,
            PasswordPolicies,
            PasswordProfile,
            PastProjects,
            PostalCode,
            PreferredDataLocation,
            PreferredLanguage,
            PreferredName,
            ProvisionedPlans,
            ProxyAddresses,
            RefreshTokensValidFromDateTime,
            Responsibilities,
            Schools,
            ShowInAddressList,
            Skills,
            SignInSessionsValidFromDateTime,
            State,
            StreetAddress,
            Surname,
            UsageLocation,
            UserPrincipalName,
            UserType,
            AgreementAcceptances,
            Activities,
            AppRoleAssignments,
            Authentication,
            Calendar,
            CalendarGroups,
            CalendarView,
            Calendars,
            ContactFolders,
            Contacts,
            CreatedObjects,
            DirectReports,
            Drive,
            Drives,
            Events,
            Extensions,
            InferenceClassification,
            Insights,
            LicenseDetails,
            MailFolders,
            Manager,
            MemberOf,
            Messages,
            Onenote,
            Outlook,
            OwnedDevices,
            OwnedObjects,
            People,
            Photo,
            Planner,
            RegisteredDevices,
            Todo,
        }
        public enum ApiPath
        {
            Users_Delta,
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
    public partial class UserDeltaResponse : RestApiResponse
    {
        public User[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeltaResponse> UserDeltaAsync()
        {
            var p = new UserDeltaParameter();
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeltaResponse> UserDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new UserDeltaParameter();
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeltaResponse> UserDeltaAsync(UserDeltaParameter parameter)
        {
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeltaResponse> UserDeltaAsync(UserDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(parameter, cancellationToken);
        }
    }
}
