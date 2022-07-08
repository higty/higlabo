using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserGetMailboxSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailboxSettings: return $"/me/mailboxSettings";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings: return $"/users/{IdOrUserPrincipalName}/mailboxSettings";
                    case ApiPath.Me_MailboxSettings_AutomaticRepliesSetting: return $"/me/mailboxSettings/automaticRepliesSetting";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_AutomaticRepliesSetting: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/automaticRepliesSetting";
                    case ApiPath.Me_MailboxSettings_DateFormat: return $"/me/mailboxSettings/dateFormat";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_DateFormat: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/dateFormat";
                    case ApiPath.Me_MailboxSettings_DelegateMeetingMessageDeliveryOptions: return $"/me/mailboxSettings/delegateMeetingMessageDeliveryOptions";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_DelegateMeetingMessageDeliveryOptions: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/delegateMeetingMessageDeliveryOptions";
                    case ApiPath.Me_MailboxSettings_Language: return $"/me/mailboxSettings/language";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_Language: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/language";
                    case ApiPath.Me_MailboxSettings_TimeFormat: return $"/me/mailboxSettings/timeFormat";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_TimeFormat: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/timeFormat";
                    case ApiPath.Me_MailboxSettings_TimeZone: return $"/me/mailboxSettings/timeZone";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_TimeZone: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/timeZone";
                    case ApiPath.Me_MailboxSettings_WorkingHours: return $"/me/mailboxSettings/workingHours";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_WorkingHours: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/workingHours";
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
            Me_MailboxSettings,
            Users_IdOruserPrincipalName_MailboxSettings,
            Me_MailboxSettings_AutomaticRepliesSetting,
            Users_IdOruserPrincipalName_MailboxSettings_AutomaticRepliesSetting,
            Me_MailboxSettings_DateFormat,
            Users_IdOruserPrincipalName_MailboxSettings_DateFormat,
            Me_MailboxSettings_DelegateMeetingMessageDeliveryOptions,
            Users_IdOruserPrincipalName_MailboxSettings_DelegateMeetingMessageDeliveryOptions,
            Me_MailboxSettings_Language,
            Users_IdOruserPrincipalName_MailboxSettings_Language,
            Me_MailboxSettings_TimeFormat,
            Users_IdOruserPrincipalName_MailboxSettings_TimeFormat,
            Me_MailboxSettings_TimeZone,
            Users_IdOruserPrincipalName_MailboxSettings_TimeZone,
            Me_MailboxSettings_WorkingHours,
            Users_IdOruserPrincipalName_MailboxSettings_WorkingHours,
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
    public partial class UserGetMailboxSettingsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync()
        {
            var p = new UserGetMailboxSettingsParameter();
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new UserGetMailboxSettingsParameter();
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync(UserGetMailboxSettingsParameter parameter)
        {
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync(UserGetMailboxSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(parameter, cancellationToken);
        }
    }
}
